using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PID
{
    class ControlPID
    {

        public ModePID mode_pid = new ModePID();
        public ParaPID para_pid = new ParaPID();
        Stat_MAXMIN stat_maxmin = new Stat_MAXMIN();
        public double[] sp = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        public double[] pv = { 0, 0.1, 0.2, 0.3, 0.4, 0.3, 0.5, 0.6, 0.9, 1, 1, 1, 1, 1, 1 };
        public double feed_fwd = 0.01;
        public double yman;
        public double[] err = new double[100];
        public double y;
        private double yio=0;
        private double ydo = 0;
        private double dt = 100;
        private double dt_lag = 0.01;
        private double y0=0;

        public ControlPID()
        {

        }

        public void calculateError(int index)
        {
            this.err[index] = sp[index] - pv[index];
        }

        public double valueYP(int index)
        {
            if (mode_pid.en_p)
            {
                double yp;
                yp = para_pid.gain * err[index];
                return yp;
            }
            else
            {
                return 0;
            }
        }

        public double valueYIMan (int index)
        {
            if (mode_pid.en_i)
            {
                double yi;
                yi = yman - (valueYP(index) - feed_fwd);
                return yi;
            }
            else
            {
                return 0;
            }
        }

        public double valueYIHalt(int index)
        {
            if (mode_pid.en_i)
            {
                double yi;
                yi = y - (valueYP(index) - feed_fwd);
                return yi;
            }
            else
            {
                return 0;
            }
        }

        public double valueYIAut(int index)
        {
            double yi;
            if (mode_pid.en_i && index>0)
            {
                yi = yio + para_pid.gain * (dt / para_pid.ti) * ((err[index] + err[index + 1]) / 2);
                return yi;
            }else if (mode_pid.en_i)
            {
                yi = yio + para_pid.gain * (dt / para_pid.ti) * ((err[index] + err[index]) / 2);
                return yi;
            }
            else
            {
                return 0;
            }
        }

        public double valueYDMan(int index)
        {
            return 0;
        }

        public double valueYDAut(int index)
        {
            double yd;
            if (mode_pid.en_d && !mode_pid.d_on_pv && index>0)
            {
                yd = (ydo * para_pid.td_lag + para_pid.td * para_pid.gain * ((err[index] - err[index-1])) / (dt + dt_lag));
                ydo = yd;
                return yd;
            }else if (mode_pid.en_d && !mode_pid.d_on_pv)
            {
                yd = (ydo * para_pid.td_lag + para_pid.td * para_pid.gain * ((err[index] - err[index])) / (dt + dt_lag));
                ydo = yd;
                return yd;
            }
            else if (mode_pid.en_d && !mode_pid.d_on_pv && index > 0)
            {
                yd = (ydo * para_pid.td_lag + para_pid.td * para_pid.gain * ((pv[index] - pv[index - 1])) / (dt + dt_lag));
                ydo = yd;
                return yd;
            }
            else if (mode_pid.en_d && mode_pid.d_on_pv)
            {
                yd = (ydo * para_pid.td_lag + para_pid.td * para_pid.gain * (pv[index]-pv[index])) / (dt + dt_lag);
                ydo = yd;
                return yd;
            }
            else
            {
                return 0;
            }
        }

        public double start(int index)
        {
            err[0] = 0;
            int type = Convert.ToInt32(mode_pid.en_p) * 100 + Convert.ToInt16(mode_pid.en_i) * 10 + Convert.ToInt16(mode_pid.en_d) ;
            if (!mode_pid.man && !mode_pid.halt)
            {
                switch (type)
                {
                    case 100:
                        y = valueYP(index) + feed_fwd;
                        break;
                    case 110:
                        y = valueYP(index) + valueYIAut(index) + feed_fwd;
                        break;
                    case 101:
                        y = valueYP(index) + valueYDAut(index) + feed_fwd;
                        break;
                    case 111:
                        y = valueYP(index) + valueYIAut(index) + valueYDAut(index) + feed_fwd;
                        break;
                    case 10:
                        y = valueYIAut(index) + feed_fwd;
                        break;
                    default:
                        y = 0;
                        break;
                }
            }
            else if ((mode_pid.man && !mode_pid.halt))
            {
                y = valueYP(index) + valueYIMan(index) + valueYDMan(index) + feed_fwd;
            }else
            {
                mode_pid.en_i = false;
                mode_pid.en_d = false;
                mode_pid.en_p = false;
                y = y0;
            }
            if (y < para_pid.ymax && y > para_pid.ymin)
            {
                y0 = y;
                return y;
            }
            else if (y > para_pid.ymax)
            {
                y0 = y;
                yio = para_pid.ymax - valueYP(index) - feed_fwd;
                return para_pid.ymax;
            }
            else
            {
                y0 = y;
                return para_pid.ymin;
            }
        }
    }
}



//qmax es qmin, switch
//haltban baj van

//halt-ban a tagok 0-ak es az elozo kimenetet tartja
//antiwindup-ban pedig ha eleri a min vagy max-ot akkor az yi tagot at kell alitani

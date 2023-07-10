#include <stdio.h>
#include <stdlib.h>

using namespace std;

int manual, stop, enable_p, enable_i, enable_d, enable_d_on_pv;
double gain, ti, td, td_lag, ymax, ymin, yi, yd, yp, off, dt;
double feed_fwd, yman;
double SP_vect[15] = { 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4 };
double PV_vect[15] = { 0, 0.5, 0.9, 0.9, 0.9, 1.1, 1.2, 1.5, 1.75, 1.9, 2.05, 2.2, 2.2, 2.3, 2.4 };
double err[15];
double y[15];

int main()
{
    manual = 0;
    stop = 0;
    enable_p = 0;
    enable_i = 0;
    enable_d = 0;
    enable_d_on_pv = 0;

    gain = 10;
    ti = 3;
    td = 0.1;
    td_lag = 0.01;
    ymax = 15;
    ymin = -15;
    dt = 1;
    yi = 0;
    yd = 0;
    off = 0;

    feed_fwd = 0.01;
    yman = 3;

    for (int i = 0; i < 15; i++) {
        err[i] = SP_vect[i] - PV_vect[i];
    }



    for (int i = 0; i < 15; i++) { //automatic mode
        if ((manual == 0) && (stop == 0)) {
            if (enable_p == 1) {
                yp = gain * err[i];
            }
            else if (enable_p == 0)
                yp = 0;

            if (enable_i == 1) {
                if (i == 0) {
                    yi = yi + gain * (dt / ti) * (err[i] / 2); // itt nem akarom negativba vinni 
                }
                else {
                    yi = yi + gain * (dt / ti) * ((err[i] + err[i - 1]) / 2);
                }
            }
            else if (enable_i == 0)
                yi = 0;

            if ((enable_d == 1) && (enable_d_on_pv == 0)) {
                if (i == 0) {
                    yd = (yd * td_lag + td * gain * err[i]) / (dt + td_lag);
                }
                else {
                    yd = (yd * td_lag + td * gain * (err[i] - err[i - 1])) / (dt + td_lag);
                }
            }
            if ((enable_d == 1) && (enable_d_on_pv == 0)) {
                if (i == 0) {
                    yd = (yd * td_lag + td * gain * PV_vect[i]) / (dt + td_lag);
                }
                else {
                    yd = (yd * td_lag + td * gain * (PV_vect[i] - PV_vect[i - 1])) / (dt + td_lag);
                }
            }
            if (enable_d == 0) {
                yd = 0;
            }
        }
        if (((manual == 1) && ((stop == 1) || (stop == 0))) || ((manual == 0) && (stop == 1))) { //manual vagy halt
            if (enable_p == 1) {
                yp = gain * err[i];
            }
            else if (enable_p == 0)
                yp = 0;

            if (enable_i == 1) {
                yi = y[i] - yp - feed_fwd;
            }
            else if (enable_i == 0) {
                yi = 0;
            }

            yd = 0;
        }

        y[i] = yp + yi + yd + off + feed_fwd;
    }

    printf("Eredmeny: \n");
    for (int i = 0; i < 15; i++) {
        printf("%f \n", y[i]);
    }
}
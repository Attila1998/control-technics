using namespace std;
#include <iostream>
#include <vector>

typedef struct {
	int type;
}ControllerType;

typedef struct {
	bool Reset;
	bool Manual;
	bool Halt;
	bool Cascade;
	bool Automatic;
	bool d_on_pv;
}OperatingMode;

typedef struct {
	double gain;
	double ti;
	double td;
	double td_lag;
	double ymax;
	double ymin;
	double feed_fwd;
	double Yman;
	double dt;
 
}Parameters;

OperatingMode SelectOperatingMode(int reset, int manual, int halt, int cascade)
{
	OperatingMode operation;
		 
	if (reset == 1) {
		operation.Reset = true;
	}
	if (reset == 0 && manual == 1) {
		operation.Manual = true;
	}
	if (reset == 0 && manual == 0 && halt == 1) {
		operation.Halt = true;
	}
	if (reset == 0 && manual == 0 && halt == 0 && cascade == 1) {
		operation.Cascade = true;
	}
	if (reset == 0 && manual == 0 && halt == 0 && cascade == 0) {
		operation.Automatic = true;
	}
	
	return operation;
}

int SelectControllerType(int en_p, int en_i, int en_d)
{
	ControllerType controller;
	
	if (en_p == 1 && en_i == 0 && en_d == 0) {
		
		controller.type = 100;
	}
	if (en_p == 0 && en_i == 1 && en_d == 0) {
		
		controller.type = 10;
	}
	if (en_p == 1 && en_i == 1 && en_d == 0) {
		
		controller.type = 110;
	}
	if (en_p == 1 && en_i == 0 && en_d == 1) {
		
		controller.type = 101;
	}
	if (en_p == 1 && en_i == 1 && en_d == 1) {
		
		controller.type = 111;
	}
	return controller.type;
}

double calculateError(double sp, double pv)/*hiba számítás mért y - elõzõ y*/ {
	double error;
	error = sp - pv;/*saved value - process value*/
	return error;
}

double calculateYP(double gain, double error)/*P tag számolása*/ {
	double YP;
	YP = gain * error;
	return YP;
}

double calcYIauto(double YIold,  double gain, double dt, double ti, double error, double errorOld)/*automata I tag visszatérítés*/ {
	double YI;
	YI = YIold + gain * (dt / ti) * ((error + errorOld) / 2);
	
	return YI;
}

double calcYImanualhalt(double Y, double YP, double FF)/*manual I tag visszatérítés*/ {
	double YI;
	YI = Y - YP - FF;
	return YI;
}

double calcYDautocascade(int d_on_pv, double YDold, double td_lag, double td, double gain, double error, double errorOld, double dt, double dt_lag, double pvOld, double pvNew) {
	double YD;
	if (d_on_pv == 0) {
		YD = (YDold * td_lag + td * gain * (error - errorOld)) / (dt + dt_lag);
		/*d-tag = régi error => kaszkád szabályzás*/
	}
	else {
		YD = (YDold * td_lag + td * gain * (pvOld - pvNew)) / (dt + dt_lag);
		/*d-tag = régi error => automata üzemmód*/
	}

	return YD;
}




int main()
{
	 double Y = 0;
	 int SPsize;
	 double sp[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };/*Set Point-referecia*/
	 double pv[] = { 0, 0.1, 0.2, 0.3, 0.4, 0.3, 0.5, 0.6, 0.9, 1, 1, 1, 1, 1, 1 };/*Process Value - folyamat érték*/
	 SPsize = sizeof(sp) / sizeof(sp[0]);

	 OperatingMode operation;
	 Parameters teszt;
	 int controllerType;
	 operation = SelectOperatingMode(0, 0, 0, 0);
	
	 int tesztNr = 2;

	 if (tesztNr == 1) {
		 controllerType = SelectControllerType(1, 0, 1); //P D
		 operation.d_on_pv = false; /*Nincs még derivált tag nicns múltbeli hiba*/
		 teszt.gain = 1;
		 teszt.ti = 1;
		 teszt.td = 1;
		 teszt.td_lag = 1;
		 teszt.ymax = 100;
		 teszt.ymin = -100;
		 teszt.feed_fwd = 0;
		 teszt.Yman = 3;
		 teszt.dt = 1;
	 }
	 else if (tesztNr == 2) {
		/*double sp[] = { 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4 };
		double pv[] = { 0, 0.5, 0.9, 0.9, 0.9, 1.1, 1.2, 1.5, 1.75, 1.9, 2.05, 2.2, 2.2, 2.3, 2.4 };*/
		 double sp[] = { 1, 1, 1, 1, 1, 1 };
		 double pv[] = { 0, 0, 0, 0, 0, 0 };
		SPsize = sizeof(sp) / sizeof(sp[0]);
		 controllerType = SelectControllerType(1, 1, 1); //P I D
		 operation.d_on_pv = true;
		 teszt.gain = 10;
		 teszt.ti = 3;
		 teszt.td = 0.1;
		 teszt.td_lag = 0.01;
		 teszt.ymax = 15;
		 teszt.ymin = -15;
		 teszt.feed_fwd = 0.01;
		 teszt.Yman = 3;
		 teszt.dt = 1;
	 }

	
	 double YP = 0, YI = 0, YD = 0;
	 double error_old = 0;
	 double YIold = 0;
	 double YDold = 0;
	 double dt_lag = teszt.td_lag;
	 double pv_old = 0;

	 cout << "Kimenet:" << endl;
	
	 for (int i = 0; i < SPsize; i++)
	 {
		 double error = calculateError(sp[i], pv[i]);
		 

		 switch (controllerType) {
		 case 100:
		 {
			 YP = calculateYP(teszt.gain, error);
			 break;
		 }

		 case 110:
		 {
			 if (operation.Automatic)
			 {
				 YP = calculateYP(teszt.gain, error);
				 YI = calcYIauto(YIold, teszt.gain, teszt.dt, teszt.ti, error, error_old);
			 }

			 else if (operation.Manual || operation.Halt) {
				 YP = calculateYP(teszt.gain, error);
				 YI = calcYImanualhalt(Y, YP, teszt.feed_fwd);
			 }
			 break;
		 }

		 case 101:
		 {
			 if (operation.Automatic || operation.Cascade)
			 {
				 YP = calculateYP(teszt.gain, error);
				 YD = calcYDautocascade(operation.d_on_pv, YDold, teszt.td_lag, teszt.td, teszt.gain, error, error_old, teszt.dt, dt_lag, pv_old, pv[i]);
			 }

			 break;
		 }

		 case 111:
		 {
			 if (operation.Automatic || operation.Cascade)
			 {
				 YP = calculateYP(teszt.gain, error);
				 YI = calcYIauto(YIold, teszt.gain, teszt.dt, teszt.ti, error, error_old);
				 YD = calcYDautocascade(operation.d_on_pv, YDold, teszt.td_lag, teszt.td, teszt.gain, error, error_old, teszt.dt, dt_lag, pv_old, pv[i]);
				 //cout << YP<<" "<< YI<<" "<< YD<<" " << endl;
			 }
			  if (operation.Manual || operation.Halt) {
				 YP = calculateYP(teszt.gain, error);
				 if (i == 0) {
					 YI = calcYImanualhalt(0, YP, teszt.feed_fwd);
				 }
				 if (i > 0) {
					 YI = calcYImanualhalt(Y, YP, teszt.feed_fwd);
				 } 
			 }

			 break;
		 }

	   }
		 error_old = error;
		 pv_old = pv[i];
		 YDold = YD;
		 YIold = YI;
		
		 Y = YP + YI + YD + teszt.feed_fwd;
		 
		 if (Y < teszt.ymin) {
			 Y = teszt.ymin;
		 }
		 else if (Y > teszt.ymax) {
			 Y = teszt.ymax;
		 }
		 
		 cout << Y << "  ";
	 }

	return 0;
}
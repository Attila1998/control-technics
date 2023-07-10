% Egyenáramú motor kaszkád szabályozása

%Paraméterek:
R = 7.13 % Ohm
L = 1.05 % mH
c1 = 1/26.6 % V/rad/sec
c2 = 0.0382 % Nm/A
J = 0.0001 % Nm^2
omega_n = 10 % rad/sec
Fv = 0.001795 % Nm/rad/sec
Tau_ext = 0.01 % Nm
csillapitas = 1.1

% Számított értékek
Ki = R % aramszabalyozasi hurok valasza 2X olyan gyors mint az eredeti rendszere
Ai = c2/(R+Ki)
Kp = (J*omega_n^2)/Ai
Kv = ((2*csillapitas*omega_n*J-Fv)/Ai)-c1


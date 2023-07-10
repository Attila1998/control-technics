clear all;
close all;
clc;

% Megadott adatok

m = 1; % kg
l = 0.2; % m
J = 0.1; % kg*m^2
g = 9.81; % m/s^2
T2sz = 1; % sec
delta_nu = 4.2; % szazalek
T = 0.1; % sec
b = 0.0011;

% számolt adatok
Eps = 0.7;
omega_n = 5.71;

%Megoldasok

    % PD + FF
    Kd_y = 2*m*Eps*omega_n;
    Kp_y = m*omega_n^2;
    
    % PID
    Kd_y_PID = (m/T)*(1+2*T*Eps*omega_n);
    Kp_y_PID = (m/T)*(2*Eps*omega_n+T*omega_n^2);
    Ki_y_PID = (m/T)*omega_n^2;
    
    % Teta 
    Kp_teta = 3.26;
    Kd_teta = 0.8;

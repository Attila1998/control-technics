clear all;
close all;
clc;

k = 0.05;
T = 10;
Tau = 3;
ref = 1;

a = (Tau/T)*k

m = menu("Szabalyzok","P szabalyzo","PI szabalyzo","PID szabalyzo","PID ref100")

if m == 1
    kp = 1/a
    e_ss = ref - 0.76
    tulloves = 0.11
    T2sz = 29.5
end

if m == 2
    kp = 0.8/a
    Ti = 3*Tau
    e_ss = ref - 1
    tulloves = 0.55
    T2sz = 39.52
end

if m == 3
    kp = 1.2/a
    Ti = 2*Tau
    Td = 0.42*Tau
    e_ss = ref - 1
    tulloves = 0.58
    T2sz = 54.27
end


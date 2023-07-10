clear all;
close all;
clc;

R=3.14;
L=1.05 * 0.001;
c1=1/26.16;
c2=38.2*10^-7;
Jr=41.9;

A=[-R/L  -c1/L  0; c2/Jr 0  0; 0 1 0];
B=[1/L 0 0; 0 -1/Jr -1/Jr; 0 0 0];
C=[0 0 1];
D=[0 0 0];

c2=38.2 *0.001;
i_no_load=74 *0.001;
Columb_surlodas=[c2*i_no_load; c2*i_no_load; c2*i_no_load];


% Megfigyelhetoseg es iranyithatosag
iranyithatosag=ctrb(A,B)
Qc_rang=rank(iranyithatosag)


megfigyelhetoseg=obsv(A,C)
Qo_rang=rank(megfigyelhetoseg)

if Qo_rang==size(A,1)
    
    disp('A rendszer megfigyelheto');
else
    disp('Nem megfigyelheto');
end


if Qc_rang==size(A,1)
    
    disp('A rendszer irányíthato');
else
    disp('Nem irányíthato');
end

allapotter=ss(A,B,C,D) 
Hs=tf(allapotter)      

visszacsatolas=feedback(Hs,Columb_surlodas) 




    
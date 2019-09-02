using System;


namespace impulse
{
    class firstvalue
    {
        
        public static double Ptur;
        public static double ω;
        public static double P00I;
        public static double P2II;
        public static double k;
        public static double T00I;
        public static double R;
        public static double viscous;
        public static double Dcp;
        public static double debi;
        public static double Wad2I;
        public static double Wads;
        public static double Wad2II;
        public firstvalue()
        {

        }
        public firstvalue(double Pturp, double ωp, double P00Ip, double P2IIp, double kp, double Tp, double Rp, double viscousp, double Dcpp, double debip,double wad2i,double wads,double wad2ii)
        {
            Ptur = Pturp;
            ω = ωp;
            P00I = P00Ip;
            P2II = P2IIp;
            k = kp;
            T00I = Tp;
            R = Rp;
            viscous = viscousp;
            Dcp = Dcpp;
            debi = debip;
            Wad2I = wad2i;
            Wads = wad2ii;
            Wad2II = wads;
            
        }
        
        public static double calcu()
        {
            double result;
            result = ω * Dcp / 2;
            //try
            //{
            //    //if ((result) < 450)
            //    //{

            //    //}
            //    //else
            //    //  throw  new invalidexeption("u =" + result + "\nu < 450 نیست");
            //}
            //catch (invalidexeption)
            //{
            //    result = -1;
            //}
            return result;
        }
    
        public static double calcδ()
        {
            
            return P00I / P2II;
        }
        public static double calcWoad()
        {
            double a = Math.Round(k / (k - 1) * R * T00I * (1 - 1 / Math.Pow(calcδ(), ((k - 1) / k))), 2);

            return Math.Round( k/(k-1)*R*T00I*(1-1/Math.Pow(calcδ(),((k-1)/k))),2);
        }
        public static double calcCad()
        {

            return Math.Sqrt((calcWoad()*2));

        }
        public static double calcspeedratio()
        {

            return calcu()/calcCad();

        }
        public static double calcworkcoef()
        {

            return (2.42781612/ calcspeedratio()-7.28);

        }
        public static double calcMdotT()
        {

            return Ptur/(calcworkcoef()*Math.Pow(calcu(),2));

        }
        public static double calcȠt()
        {

            return calcworkcoef()*Math.Pow(calcu(),2)/calcWoad();

        }
        public static double calcρTI()
        {

            return Wad2I  / calcWoad();

        }
        public static double calcρTS()
        {

            return Wads / calcWoad();

        }
        public static double calcρTII()
        {

            return Wad2II / calcWoad();

        }

    }
}

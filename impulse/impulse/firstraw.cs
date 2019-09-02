using System;

namespace impulse
{
    class firstraw : nozel
    {
        // 55
        public static double calcw1I()
        {

            return (double)Math.Sqrt(Math.Pow( calcC1I()*Math.Cos((double)outputangle)-calcu(),2)+ Math.Pow(calcC1I() * Math.Sin((double)outputangle),2));
        }
        // 56
        public static double calcMstaruI()
        {

            return calcu()/calcastarCI();
        }
        // 57
        public static double calcT0WI()
        {

            return T00I*(1-(k-1)/(k+1)*(2*calcMstaruI()*calcMstarc1I()*Math.Cos(outputangle)-Math.Pow(calcMstaruI(),2)));
        }
        // 58
        public static double calcastarwI()
        {

            return Math.Sqrt(2*k/(k+1)*R*calcT0WI());
        }
        // 59
        public static double calcMstarw1I()
        {

            return calcw1I()/calcastarwI();
        }
        // 60
        public static double calcMw1I()
        {

            return Math.Sqrt(2/(k+1)*(Math.Pow(calcMstarw1I(),2)/(1-(k-1)/(k+1)*Math.Pow(calcMstarw1I(),2))));
        }
        // 61
        public static double calcP0w1I()
        {

            return calcP01I()*Math.Pow( ((1-(k-1)/(k+1)*Math.Pow(calcMstarc1I(),2))/(1-(k-1)/(k+1)*Math.Pow(calcMstarw1I(),2))),k/(k-1));
        }
        // 62
        public static double calcbeta1II()
        {

            return (Math.Tanh(Math.Sin(outputangle) / (Math.Cos(outputangle) - calcu() / calcC1I())) );
        }
        public static double calcbeta1I()
        {

            return  (Math.Tanh(Math.Sin(outputangle)/(Math.Cos(outputangle)-calcu()/calcC1I())) * 180 / Math.PI);
        }
        // 63
        public static double calcw2adI()
        {
            double a = Convert.ToDouble(Math.Sqrt(Math.Pow(calcw1I(), 2) + 0));
            return Convert.ToDouble(Math.Sqrt(Math.Pow(calcw1I(),2)+0));
        }
        // 64
        public static double calcT02wadI()
        {

            return calcT0WI();
        }
        // 65
        public static double calcT2adI()
        {

            return calcT02wadI()-(k-1)/(2*k*R)*Math.Pow(calcw2adI(),2);
        }
        // 66
        public static double calca2adI()
        {

            return Math.Sqrt(k*R*calcT2adI());
        }
        // 67
        public static double calcM2TI()
        {

            return calcw2adI()/calca2adI();
        }

    }
}

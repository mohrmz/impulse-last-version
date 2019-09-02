using System;


namespace impulse
{
    class mapprofile : chooseprofilefirstlevel
    {
        public static double kesi;
        //public static double beta2ef;
        public static double mdotbary;
        public mapprofile()
        { }
        public mapprofile(double pkesi,double pmdotbary)
        { kesi = pkesi; mdotbary = pmdotbary; }
        //80
        public static double calcsi1()
        {

            return Math.Sqrt(1-kesi);
        }
        //81
        public static double calcbeta2ef()
        {

            return calcbeta1II();
        }
        //82
        public static double calcw2I()
        {

            return calcsi1() * calcw2adI();
        }
        //83
        public static double calcMsarw2I()
        {

            return calcw2I()/calcastarwI();
        }
        //84
        public static double calcsigma2I()
        {

            return Math.Pow((1-(k-1)/(k+1)*Math.Pow(calcMsarw2I()/calcsi1(),2))/(1-(k-1)/(k+1)*Math.Pow(calcMsarw2I(),2)),k/(k-1));
        }
        //85
        public static double calcqMstarw2I()
        {

            return calcMsarw2I()*Math.Pow(((k+1)/2*(1-(k-1)/(k+1)*Math.Pow(calcMsarw2I(),2))),1/(k-1));
        }
        //87
        public static double calcmdotprimeT()
        {

            return calcMdotT()*(1-mdotbary);
        }
        //88
        public static double calch2bI()
        {
            return calchinI();
            //return (mdotbary*Math.Sqrt(R*calcT0WI())/(calcε1()*Math.PI*Dcp*calcP0w1I()*calcsigma2I()))*(1/(calcqMstarw2I()*Math.Sqrt(k*Math.Pow(2/(k+1),(k+1)/(k-1))*Math.Sin(calcbeta2ef()))));
        }
        //89
        public static double calcT2I()
        {

            return calcT0WI()-(k-1)/(2*k*R)*Math.Pow(calcw2I(),2);
        }
        //90
        public static double calcC2I()
        {

            return Math.Sqrt(Math.Pow(calcw2I()*Math.Sin(calcbeta2ef()),2)+Math.Pow(calcw2I()*Math.Cos(calcbeta2ef())-calcu(),2));
        }
        //91
        public static double calcalpha2I()
        {
            //return 
            return Math.Tanh((calcw2I() * Math.Sin(calcbeta2ef())) / (calcw2I() * Math.Cos(calcbeta2ef()) - calcu())) * (180 / Math.PI);
        }
        public static double calcalpha2II()
        {
            //return 
            return Math.Tanh((calcw2I() * Math.Sin(calcbeta2ef())) / (calcw2I() * Math.Cos(calcbeta2ef()) - calcu())) ;
        }
        //92
        public static double calcT02I()
        {

            return calcT2I()+(k-1)/(2*k*R)*Math.Pow(calcC2I(),2);
        }
        //93
        public static double calcastarC2I()
        {

            return Math.Sqrt(2*k*R*calcT02I()/(k+1));
        }
        //94
        public static double calcMstarC2I()
        {

            return calcC2I()/calcastarC2I()  ;
        }
        //95
        public static double calcP02i()
        {

            return calcP1I()/Math.Pow((1-(k-1)/(k+1)*Math.Pow(calcMstarC2I(),2)),k/(k-1));
        }
    }
}

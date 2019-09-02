using System;


namespace impulse
{
    class turbin : mapprofile
    {
        public static double delta;
        public turbin()
        { }
        public turbin(double pdelta)
        { delta = pdelta; }

        // 96
        public static double calcWuI()
        {
            double a = calcu() * (calcC1I() * Math.Cos(outputangle) - calcC2I() * Math.Cos(Math.PI - calcalpha2II()));

            return calcu() * (calcC1I() * Math.Cos(outputangle) - calcC2I() * Math.Cos(Math.PI - calcalpha2II()));
        }
        // 97
        public static double calcWu()
        {

            return calcWuI();
        }
        // 98
        public static double calcetau()
        {

            return calcWu() / calcWoad();
        }
        // 99
        public static double calcetakI()
        {

            return 1 - (0.003 / ((hbarbI / Dcp) + 0.003));
        }
        // 100
        public static double calcReg()
        {

            return calcρ1I()*((Math.Pow(Dcp,2)*ω)/(4*viscous));
        }
        // 101
        public static double calcffric_disk()
        {

            return 0.039/Math.Pow( calcReg(),0.2);
        }
        // 101
        public static double calcffric_diskTur()
        {

            return 0.039 / Math.Pow(calcReg(), 0.2);
        }
        // 102
       
        public static double f_fricK_disK()
        {

            return 2 * calcffric_disk() * calcρ1I() * Math.Pow(Dcp / 2, 5) * Math.Pow(ω, 3);
        }
       


        public static double calcPfric_diskTur()
        {

            return calcffric_disk()* calcρ1I()*Math.Pow(Dcp/2,5)*Math.Pow(ω,3);
        }
        // 103
        public static double calcDband()
        {

            return Dcp + calchinI() + 0.0035;
                
        }
        // 104
        public static double calcDeltar1()
        {

            return 0.03*calcDband()/2;

        }
        // 105
        public static double calcReband()
        {

            return (calcρ1I()*ω*calcDband()*calcDeltar1())/(2*viscous);

        }
        // 106
        public static double calcffric_band()
        {

            return 0.1/(Math.Sqrt(calcReband()));

        }
        // 107
        public static double calcbband()
        {

            return calcBIB() + 0.0022;

        }
        // 108
        public static double calcfpfric_band()
        {

            return 0.1/Math.Pow(calcReband(),0.5);

        }
        //f_fric_band =0.1/(Re_band^0.5);
        public static double calcPfric_band()
        {

            return calcfpfric_band()* calcρ1I()*Math.Pow(ω,3)*calcbband()*Math.Pow(calcDband(),4);

        }
        // 109
        public static double calcPepsilonI()
        {
            double d = calcρ1I();
            double f = calchinI();
            double g = calcBIB();
            double df = calcε1();
            double a = 0.015 * calcρ1I() * (calchinI() / Dcp) * (1 + (10 * calcBIB() / Dcp)) * (1 - calcε1()) * Math.Pow(ω, 3) * Math.Pow(Dcp, 5); 
            return 0.015* calcρ1I()*(calchinI()/Dcp)*(1+(10* calcBIB() / Dcp))*(1- calcε1()) *Math.Pow( ω,3)*Math.Pow(Dcp,5);

        }
        // 110
        public static double calcPTad()
        {

            return calcMdotT()*calcWoad();

        }
        // 111
        public static double calcPT()
        {
            double s = calcPTad();
            double f = calcetau();
            double g = (1 - mdotbary);
            double k = calcPfric_diskTur();
            double l = calcPfric_band();
            double r = -calcPepsilonI();
           double a = calcPTad() * calcetau() * calcetakI() * (1 - mdotbary) - calcPfric_diskTur() - calcPfric_band() - calcPepsilonI();
            return calcPTad()*calcetau()*calcetakI()*(1-mdotbary)-calcPfric_diskTur()-calcPfric_band()-calcPepsilonI();

        }
        // 112
        public static double calcWT()
        {

            return  calcPT()/calcMdotT();

        }
        // 113
        public static double calcetaT()
        {

            return calcWT()/calcWoad();

        }
        // 114
        public static double calcWbarT()
        {

            return calcWT()/Math.Pow(calcu(),2);

        }
        // 115
        public static double calcetau2()
        {

            return 2*Math.Pow(speedcoef,2)*(1+calcsi1())*calcu()/(calcCad()*speedcoef)*((1+Math.Pow(calcsi1(),2))*(Math.Cos(outputangle-calcu()/(speedcoef*calcCad())))-(1+calcsi1()*calcu()/(calcCad()*speedcoef)));

        }
        // 116
        public static double calcepsilonfric_disk()
        {

            return 0.32*((calcffric_diskTur()*Math.Pow(1-(calchinI()/(Dcp)),5))/(calcε1()*calchinI()/Dcp*speedcoef*Math.Sin(openconeangle)))*Math.Pow(calcu()/calcCad(),3);

        }
        // 117
        public static double calcepsilonfric_band()
        {

            return 5.1 * ((calcffric_diskTur() *(calcbband()/Dcp)* Math.Pow(1 - (calchinI() / (Dcp)), 4)) / (calcε1() * calchinI() / Dcp * speedcoef * Math.Sin(openconeangle))) * Math.Pow(calcu() / calcCad(), 3);

        }
        // 118
        public static double calcepsilonepsilonI()
        {

            return 0.075*(1+(10*(calcBIB()))/(Dcp))/(speedcoef*Math.Sin(outputangle))*((1- calcε1()) /(calcε1()))*Math.Pow(calcu()/calcCad(),3);

        }
        // 119
        public static double calcetaT2()
        {

            return calcetau()*calcetakI()*(1-mdotbary)-calcepsilonfric_disk()-calcepsilonfric_band()-calcepsilonepsilonI();

        }
       
        // 121
        public static double calcetaTmax()
        {

            return 0.22*delta+0.4;

        }
        // 122
        //public static double calcetaT()
        //{

        //    return ;

        //}

    }
}

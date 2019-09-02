using System;


namespace impulse
{
    class nozel : firstvalue
    {

        public static double speedcoef;
        public static double installcoefangle;
        public static double outputangle;
        public static double hneavr;
        public static double speedconecoef;
        public static double openconeangle;
        public nozel()
        {

        }

        public nozel(double spedc,double instaldeg,double hnep,double spdconecoef,double openconep)
        {
            speedcoef = spedc;
            installcoefangle = instaldeg;
            outputangle = instaldeg;
            hneavr = hnep;
            speedconecoef = spdconecoef;
            openconeangle = openconep;
        }
        public static double calcwad1I()
        {
            double a = calcWoad();
           double b = (1 - calcρTI() - calcρTII() - calcρTS());
            
            return Math.Round( calcWoad() * (1 - calcρTI() - calcρTII() - calcρTS()),2);
        }
        public static double calcc1adI()
        {

            return Math.Sqrt( 2*calcwad1I());
        }
        public static double calcC1I()
        {

            return calcc1adI() * speedcoef;
        }
        public static double calcastarCI()
        {

            return Math.Sqrt( (2*(k/(k+1))*R*T00I));
        }
        public static double calcMstarc1I()
        {

            return calcC1I()/ calcastarCI();
        }
        public static double calcσ1I()
        {

            return Math.Pow(((1-((k-1)/(k+1))* Math.Pow((calcMstarc1I()/speedcoef),2))/(1-((k-1)/(k+1))*Math.Pow(calcMstarc1I(),2))),((k)/(k-1)));
        }
        public static double calcP01I()
        {

            return Math.Round( calcσ1I()*P00I,2);
        }
        public static double calcP1I()
        {

            return P00I * Math.Pow((1-((k-1)/k)*(calcwad1I()/(R*T00I))),(k/(k-1)));
        }
        public static double calcT1I()
        {

            return T00I * (1 - ((k - 1) / (k + 1)) * Math.Pow(calcMstarc1I(), 2));
        }
        public static double calcρ1I()
        {
            double re = calcP1I() / (R * calcT1I());
            return re;
        }
        public static double calca1I()
        {

            return Math.Sqrt((k*R*calcT1I()));
        }
        public static double calcM1I()
        {

            return calcC1I()/calca1I();
        }
        public static double calchne()
        {

            return hneavr* Dcp;
        }
        public static double calcσStar1()
        {

            return Math.Pow(((1-((k-1)/(k+1))*(1/speedcoef)*(1/speedcoef))/(1-((k-1)/(k+1)))),(k/(k-1)));
        }
        public static double calcσprime1()
        {

            return Math.Pow(((1 - ((k - 1) / (k + 1)) * (calcMstarc1I() / speedcoef) * (calcMstarc1I() / speedcoef)) / (1 - ((k - 1) / (k + 1))*Math.Pow(calcMstarc1I(), 2))), (k / (k - 1)));
        }
        public static double calcFmin()
        {

            return (calcMdotT()*Math.Sqrt((R*T00I)))/(Math.Sqrt((k*Math.Pow((2/(k+1)),((k+1)/(k-1)) )))* calcσStar1()*P00I);
        }
        public static double calcpressconeratio()
        {
            double c = calcMstarc1I();
            double a = Math.Pow(((1 - (k - 1) / (k + 1) * Math.Pow((calcMstarc1I() / speedconecoef), 2)) / (1 - (k - 1) / (k + 1) * Math.Pow(calcMstarc1I(), 2))), ((k) / (k - 1)));
            return Math.Pow(((1 - (k - 1) / (k + 1) * Math.Pow((calcMstarc1I() / speedconecoef), 2)) / (1 - (k - 1) / (k + 1) * Math.Pow(calcMstarc1I(), 2))), ((k) / (k - 1)));
            ;
        }
        public static double calcPstar()
        {

            return P00I * Math.Pow((2/(k+1)),(k/(k-1))  )          ;
        }
        public static double calcTstar()
        {

            return T00I*(2/(k+1));
        }
        public static double calcdensitystar()
        {

            return calcPstar()/(R*calcTstar());
        }
        public static double calcFprm1()
        {
            double b = calcFmin();
            double c = calcdensitystar();
            double q = calcastarCI();
            double d = calcρ1I();
            double g = calcC1I();
            double k = calcpressconeratio();
            double a = 1.92 * calcFmin() * ((calcdensitystar() * calcastarCI()) / (calcρ1I() * calcC1I() * calcpressconeratio()));
            return 1.92 * calcFmin()*((calcdensitystar()* calcastarCI())/(calcρ1I()*calcC1I()*calcpressconeratio()));
        }
        public static double calcFNe()
        {

            return calcFprm1() / Math.Sin(installcoefangle);
        }
        public static double calcε1()
        {
            double a = calcFNe();
            double b = Dcp;
            double c = calchne();
            return calcFNe() / ((Math.PI)*Dcp*calchne());
        }
        public static double calcNN()
        {
            double a = Math.Floor((4 * calcFprm1()) / (Math.PI * calchne()));
            double g = (4 * calcFprm1());
            double k = Math.PI * calchne();
            double b = calcFprm1();
            double c = calchne();
            return Math.Floor( (4 * calcFprm1()) / (Math.PI * calchne()* calchne()));
        }
        public static double calchne2()
        {

            return Math.Sqrt((4*calcFprm1())/(Math.PI*calcNN()));
        }
        public static double calcaNe()
        {

            return calchne()/Math.Sin(installcoefangle);
        }
        public static double calctN()
        {

            return (calcaNe()*(0.96));
        }
        public static double calcdmin()
        {

            return Math.Sqrt( (4*calcFmin()/(Math.PI*calcNN())));
        }
        public static double calclstar()
        {

            return ((calchne()-calcdmin())/(2*Math.Tan(openconeangle/2)));
        }
        


    }
}

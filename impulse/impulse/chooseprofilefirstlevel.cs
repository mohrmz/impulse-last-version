using System;


namespace impulse
{

    class chooseprofilefirstlevel:firstraw
    {
        public static double deltahtipI;
        public static double deltahhubI;
        public static double delzaZI;
        public static double hbarbI;
        
        public static double profileinstall;
        public static double tbarbI;
        public chooseprofilefirstlevel(double pdeltahtipI, double pdeltahhubI, double pdelzaZI, double phbarbI , double pprofileinstall, double ptbarbI)
        {
            deltahtipI = pdeltahtipI;
            deltahhubI = pdeltahhubI;
            delzaZI = pdelzaZI;
            hbarbI = phbarbI;
            
            profileinstall = pprofileinstall;
            tbarbI = ptbarbI;
        }
        public chooseprofilefirstlevel()
        { }
        // 68
        public static double calchinI()
        {

            return calchne()+deltahtipI+deltahhubI;
        }
        public static double calcBIB()
        {

            return calchinI() / hbarbI;
        }
        // 76
        public static double calctprimebI()
        {

            return tbarbI*calcBIB();
        }
        // 77
        public static double calcNbI()
        {

            return Math.PI * Dcp/calctprimebI();
        }
        // 78
        public static double calctbI()
        {

            return Math.PI*Dcp/calcNbI();
        }
        
    }
}

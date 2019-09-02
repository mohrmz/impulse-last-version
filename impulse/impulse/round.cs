using Newtonsoft.Json;
using System;
using System.IO;


namespace impulse
{
    class round
    {
        public round()
        {

        }
        public string rond(double Pint)

        {
            setting s = new setting();
            
            
           
            return Math.Round(Pint, s.round).ToString(); 
           

        }
        public double rondd(double Pint)

        {
            setting s = new setting();

            return Math.Round(Pint, s.round);

        }

    }
}

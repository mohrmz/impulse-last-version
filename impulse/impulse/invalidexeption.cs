using System;

namespace impulse
{
    class invalidexeption : ApplicationException
    {
     
        public invalidexeption(string error) : base (error)
        {
            Impulse.error(error);

        }
      
       
    }
}

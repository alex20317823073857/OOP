using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facilities
{
    public class Client
    {
        Facade facade = new Facade();

        public int DoCalls()
        {
            
            int counter = 0;

            while (!CallSupport())
            {
                CallSupport();
            }

            return counter;
        }

        bool CallSupport()
        {
            facade.DoWorkCalls();
            return facade.CurrentStateOfWork();
        }
    }
}

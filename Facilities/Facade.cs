using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facilities
{
    public class Facade
    {
        public Support support = new Support();

        public int DoWorkCalls()
        {
            int counter = 0;
            
            support.Engineer.SubmitNetworkRequest();
            support.Electrician.SubmitNetworkRequest();
            support.Technician.SubmitNetworkRequest();

            bool electicianDone = false;
            bool engineerDone = false;
            bool technicianDone = false;

            while (!technicianDone)
            {
                counter++;
                if (!engineerDone)
                    engineerDone = CallEngineer();
                else if (engineerDone && !electicianDone)
                    electicianDone = CallElectrician();
                else if (electicianDone && !technicianDone)
                    technicianDone = CallTechnician();
            }

            return counter;
        }


        bool CallElectrician()
        {
            // Если электрик свою работу выполнил, 
            // перенаправим запрос технику
            if (support.Electrician.CheckOnStatus())
            {
                support.Technician.SubmitNetworkRequest();
                return true;
            }

            return false;
        }

        bool CallEngineer()
        {
            // Если инженер свою работу выполнил, 
            // перенаправим запрос электрику
            if (support.Engineer.CheckOnStatus())
            {
                support.Electrician.SubmitNetworkRequest();
                return true;
            }

            return false;
        }

        bool CallTechnician()
        {
            // Если техник свою работу выполнил, 
            // то запрос обслужен до конца
            if (support.Technician.CheckOnStatus())
                return true;

            return false;
        }

        public bool CurrentStateOfWork()
        {
            DoWorkCalls();
            return CallTechnician();
        }
    }
}
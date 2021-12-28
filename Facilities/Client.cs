using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facilities
{
    public class Client
    {
        Support support;

        public int DoCalls()
        {
            int counter = 0;

            support = new Support();
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
    }
}

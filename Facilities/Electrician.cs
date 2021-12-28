using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facilities
{
    public class Electrician
    {
        enum State
        {
            Received, RejectTheForm, SizeTheJob, SmokeAndJokeBreak,
            WaitForAuthorization, DoTheWrongJob, BlameTheEngineer,
            WaitToPunchOut, DoHalfAJob, ComplainToEngineer,
            GetClarification, CompleteTheJob, TurnInThePaperwork,
            Complete
        };

        State state;

        public void SubmitNetworkRequest()
        {
            state = 0;
        }
        public bool CheckOnStatus()
        {
            state++;
            if (state == State.Complete)
                return true;
            return false;
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facilities
{
    public class FacilitiesEngeneer
    {
        enum State
        {
            Received, AssignToEngineer, EngineerResearches,
            RequestIsNotPossible, EngineerLeavesCompany,
            AssignToNewEngineer, NewEngineerResearches,
            ReassignEngineer, EngineerReturns,
            EngineerResearchesAgain, EngineerFillsOutPaperWork,
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

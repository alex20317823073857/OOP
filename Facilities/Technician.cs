using System;

namespace Facilities
{
    public class Technician
    {
        enum State
        {
            Received, DenyAllKnowledge, ReferClientToFacilitiesEngeneer,
            FacilitiesHasNotSentPaperwork, ElectricianIsNotDone,
            ElectricianDidItWrong, DispatchTechnician, SignedOff,
            DoesNotWork, FixElectriciansWiring, Complete
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

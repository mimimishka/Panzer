using strange.extensions.mediation.impl;

namespace Panzer
{
    public class TimerMediator : Mediator
    {
        [Inject]
        public TimerView View { get; private set; }
        [Inject]
        public TimeElapsedSignal TimeElapsedSignal { get; private set; }

        public override void OnRegister()
        {
            View.Dispatcher.UpdateListener(true, TimerView.TICK, OnTick);
            View.Init();
        }
        void OnTick()
        {
            TimeElapsedSignal.Dispatch();
        }
    }
}
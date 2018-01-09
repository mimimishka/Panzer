using strange.extensions.mediation.impl;

namespace Panzer
{
    public class GameOverUIMediator : Mediator
    {
        [Inject]
        public GameOverUIView View { get; private set; }
        [Inject]
        public OnGameCloseSignal CloseSignal { get; private set; }
        [Inject]
        public OnGameRestartSignal RestartSignal { get; private set; }

        public override void OnRegister()
        {
            View.Dispatcher.UpdateListener(true, GameOverUIView.RESTART, OnRestart);
            View.Dispatcher.UpdateListener(true, GameOverUIView.CLOSE, OnClose);
        }
        void OnRestart()
        {
            RestartSignal.Dispatch();
        }
        void OnClose()
        {
            CloseSignal.Dispatch();
        }
    }
}
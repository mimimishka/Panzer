using strange.extensions.mediation.impl;

namespace Panzer
{
    public class KeyboardInputMediator : Mediator
    {
        [Inject]
        public KeyboardInputView View { get; private set; }
        [Inject]
        public TurnPanzerSignal TurnSignal { get; private set; }
        [Inject]
        public DrivePanzerSignal DriveSignal { get; private set; }
        [Inject]
        public InputControls Controls { get; private set; }
        [Inject]
        public TurretChangeSignal TurretChange { get; private set; }
        [Inject]
        public AttackSignal AttackSignal { get; private set; }
        [Inject]
        public GameOverSignal GameOverSignal { get; private set; }

        public override void OnRegister()
        {
            UpdateListeners(true);
            GameOverSignal.AddListener(() => UpdateListeners(false));
            View.Init(Controls);
        }
        void UpdateListeners(bool val)
        {
            View.Dispatcher.UpdateListener(val, KeyboardInputView.TURN_LEFT, () => OnTurn(-1.0f));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.TURN_RIGHT, () => OnTurn(1.0f));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.DRIVE_FORWARD, () => OnDrive(1.0f));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.DRIVE_BACKWARD, () => OnDrive(-1.0f));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.PREV_GUN, () => OnTurretChange(-1));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.NEXT_GUN, () => OnTurretChange(1));
            View.Dispatcher.UpdateListener(val, KeyboardInputView.ATTACK, () => OnAttack());
        }
        void OnTurn(float mult)
        {
            TurnSignal.Dispatch(mult);
        }
        void OnDrive(float mult)
        {
            DriveSignal.Dispatch(mult);
        }
        void OnTurretChange(int dir)
        {
            TurretChange.Dispatch(dir);
        }
        void OnAttack()
        {
            AttackSignal.Dispatch();
        }
    }
}
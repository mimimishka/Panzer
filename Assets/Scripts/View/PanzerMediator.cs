using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Panzer
{
    public class PanzerMediator : Mediator
    {
        [Inject]
        public PanzerView View { get; set; }
        [Inject]
        public PanzerModel Model { get; set; }
        [Inject]
        public TurretsSet TurretsSet { get; private set; }
        [Inject]
        public PanzerAttackedSignal AttackedSignal { get; private set; }
        [Inject]
        public GameOverSignal GameOverSignal { get; private set; }

        public override void OnRegister()
        {
            UpdateListeners(true);
            Model.GunId.Subscribe(id => ChangeTurret(id));
            GameOverSignal.AddListener(View.Die);
            GameOverSignal.AddListener(() => UpdateListeners(false));
            View.Init();
        }
        void ChangeTurret(int id)
        {
            View.MountTurret(TurretsSet[id]);
        }
        void OnAttacked(IEvent evt)
        {
            AttackedSignal.Dispatch(evt.data as MonsterView);
        }
        void UpdateListeners(bool val)
        {
            View.Dispatcher.UpdateListener(val, PanzerView.MONSTER_COL, OnAttacked);
        }
    }
}
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Panzer
{
    public class MonsterMediator : Mediator
    {
        [Inject]
        public MonsterView View { get; private set; }
        [Inject]
        public MonsterAttackedSignal AttackedSignal { get; private set; }
        [Inject]
        public MonsterDeficitSignal DeficitSignal { get; private set; }
        [Inject]
        public MonsterDeadSignal DeadSignal { get; private set; }
        [Inject(name = MonsterValue.MONSTER_INC)]
        public int MonsterIncrement { get; private set; }

        public override void OnRegister()
        {
            View.Model.Health.Subscribe(h => View.UpdateHealth(h));
            View.Dispatcher.UpdateListener(true, MonsterView.ON_HIT, OnHit);
            View.Dispatcher.UpdateListener(true, MonsterView.ON_DIE, OnDie);

            View.Init();
        }
        void OnHit(IEvent evt)
        {
            float? dmg = evt.data as float?;
            AttackedSignal.Dispatch
            (
                View.Model,
                dmg == null ? 0f : dmg.Value
            );
        }
        void OnDie()
        {
            DeficitSignal.Dispatch(MonsterIncrement);
            DeadSignal.Dispatch();
        }
    }
}
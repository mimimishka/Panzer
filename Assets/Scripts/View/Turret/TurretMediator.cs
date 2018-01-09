using strange.extensions.mediation.impl;

namespace Panzer
{
    public class TurretMediator : Mediator
    {
        [Inject]
        public TurretView View { get; private set; }
        [Inject]
        public AttackSignal AttackSignal { get; private set; }

        public override void OnRegister()
        {
            AttackSignal.AddListener(View.Shoot);
        }
        public override void OnRemove()
        {
            AttackSignal.RemoveListener(View.Shoot);
        }
    }
}
using strange.extensions.mediation.impl;
using UniRx;

namespace Panzer
{
    public class PlayerUIMediator : Mediator
    {
        [Inject]
        public PlayerUIView View { get; private set; }
        [Inject]
        public TurretsSet Turrets { get; private set; }
        [Inject]
        public PanzerModel PanzerModel { get; private set; }
        [Inject]
        public GameModel GameModel { get; private set; }

        public override void OnRegister()
        {
            PanzerModel.GunId.Subscribe
            (
                id =>
                    View.UpdateDamage(Turrets[id].Damage)
            );
            PanzerModel.Health.Subscribe
            (
                h =>
                    View.UpdateHealth(h / PanzerModel.MaxHealth.Value)
            );
            PanzerModel.Protection.Subscribe
            (
                p =>
                    View.UpdateProtection(p)
            );
            GameModel.Score.Subscribe
            (
                s =>
                    View.UpdateScore(s)
            );
        }
    }
}
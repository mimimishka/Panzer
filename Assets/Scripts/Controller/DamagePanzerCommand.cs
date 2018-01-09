using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class DamagePanzerCommand : Command
    {
        [Inject]
        public PanzerModel PanzerModel { get; private set; }
        [Inject]
        public MonsterView Enemy { get; private set; }
        [Inject]
        public GameOverSignal GameOverSignal { get; private set; }

        public override void Execute()
        {
            float newHealth = PanzerModel.Health.Value;
            newHealth -= Enemy.Model.Damage.Value * PanzerModel.Protection.Value;
            newHealth = Mathf.Clamp(newHealth, 0f, PanzerModel.MaxHealth.Value);
            PanzerModel.Health.Value = newHealth;
            Enemy.Die();
            if (PanzerModel.Health.Value == 0f)
                GameOverSignal.Dispatch();
        }
    }
}
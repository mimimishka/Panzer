using strange.extensions.command.impl;

namespace Panzer
{
    public class DamageMonsterCommand : Command
    {
        [Inject]
        public MonsterModel Model { get; private set; }
        [Inject]
        public float Damage { get; private set; }

        public override void Execute()
        {
            float newHealth = Model.Health.Value;
            newHealth -= Damage * Model.Protection.Value;
            if (newHealth < 0f)
                newHealth = 0f;
            Model.Health.Value = newHealth;
        }
    }
}
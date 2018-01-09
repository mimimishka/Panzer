using strange.extensions.command.impl;

namespace Panzer
{
    public class InitGameCommand : Command
    {
        [Inject]
        public MonsterDeficitSignal DeficitSignal { get; private set; }
        [Inject]
        public PanzerConfig PanzerConfig { get; private set; }
        [Inject]
        public PanzerModel PanzerModel { get; private set; }
        [Inject(name =MonsterValue.MONSTER_INIT)]
        public int MonsterInitAmount { get; private set; }

        public override void Execute()
        {
            PanzerModel.MaxHealth.Value = PanzerModel.Health.Value = PanzerConfig.Health;
            PanzerModel.Protection.Value = PanzerConfig.Protection;
            DeficitSignal.Dispatch(MonsterInitAmount);
        }
    }
}
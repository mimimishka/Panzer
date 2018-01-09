using strange.extensions.command.impl;

namespace Panzer
{
    public class IncreaseScoreCommand : Command
    {
        [Inject]
        public GameModel Model { get; private set; }
        public override void Execute()
        {
            ++Model.Score.Value;
        }
    }
}
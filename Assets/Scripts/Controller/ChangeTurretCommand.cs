using strange.extensions.command.impl;

namespace Panzer
{
    public class ChangeTurretCommand : Command
    {
        [Inject]
        public PanzerModel Model { get; private set; }
        [Inject]
        public TurretsSet TurretsSet { get; private set; }

        [Inject]
        public int Direction { get; private set; }

        public override void Execute()
        {
            int newId = Model.GunId.Value;
            newId += Direction;
            //loop gun id
            if (newId < 0)
                newId = TurretsSet.Count - 1;
            else if (newId >= TurretsSet.Count)
                newId = 0;
            Model.GunId.Value = newId;
        }
    }
}
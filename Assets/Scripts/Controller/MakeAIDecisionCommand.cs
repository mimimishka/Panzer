using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class MakeAIDecisionCommand : Command
    {
        public override void Execute()
        {
            foreach(MonsterView view in GameObject.FindObjectsOfType<MonsterView>())
                if(!view.Dead)
                    view.NavAgent.SetDestination(view.Target.position);
        }
    }
}
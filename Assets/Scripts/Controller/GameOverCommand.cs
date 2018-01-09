using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class GameOverCommand : Command
    {
        public override void Execute()
        {
            GameObject.FindObjectOfType<TimerView>()
                .Stop();
            foreach(MonsterView monster in GameObject.FindObjectsOfType<MonsterView>())
            {
                if (monster.Dead)
                    continue;
                monster.Stop();
                monster.NavAgent.isStopped = true;
            }
            GameObject.FindObjectOfType<GameOverUIView>().Activate();
        }
    }
}
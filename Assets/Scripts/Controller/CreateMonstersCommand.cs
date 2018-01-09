using UnityEngine;
using UnityEngine.AI;
using strange.extensions.command.impl;

namespace Panzer
{
    public class CreateMonstersCommand : Command
    {
        [Inject]
        public int Amount { get; private set; }
        [Inject]
        public EnemiesConfig Config { get; private set; }
        [Inject]
        public SpawPointsSet SpawnsSet { get; private set; }

        int GetRandomConfigIndex() { return Random.Range(0, Config.EnemiesConfigs.Count); }
        Transform GetRandomSpawn()
        {
            return SpawnsSet.SpawnPoints[Random.Range(0, SpawnsSet.SpawnPoints.Count)];
        }

        public override void Execute()
        {
            for (int i = 0; i < Amount; ++i)
            {
                int randInd = GetRandomConfigIndex();
                Transform spawn = GetRandomSpawn();
                NavMeshHit hit;
                if (NavMesh.SamplePosition(spawn.position, out hit, float.MaxValue, ~0))
                {
                    MonsterView view = GameObject.Instantiate
                    (
                        Config.EnemiesConfigs[randInd].View.gameObject,
                        hit.position,
                        spawn.rotation
                    )
                      .GetComponent<MonsterView>();
                    view.Model = new MonsterModel(Config.EnemiesConfigs[randInd].ModelPrototype);
                    view.NavAgent.Warp(hit.position);
                }
            }
        }
    }
}
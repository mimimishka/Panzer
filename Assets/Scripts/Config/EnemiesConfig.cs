using System.Collections.Generic;
using UnityEngine;

namespace Panzer
{
    [CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Enemies config")]
    public class EnemiesConfig : ScriptableObject
    {
        [SerializeField]
        List<EnemyConfig> configs;
        public List<EnemyConfig> EnemiesConfigs { get { return configs; } }
    }
    [System.Serializable]
    public class EnemyConfig
    {
        [SerializeField]
        EnemyModelProto modelPrototype;
        [SerializeField]
        MonsterView view;

        public EnemyModelProto ModelPrototype { get { return modelPrototype; } }
        public MonsterView View { get { return view; } }
    }
    [System.Serializable]
    public class EnemyModelProto
    {
        [SerializeField]
        float health;
        [SerializeField]
        float damage;
        [SerializeField]
        float protection = .8f;

        public float Health { get { return health; } }
        public float Damage { get { return damage; } }
        public float Protection { get { return protection; } }
    }
}
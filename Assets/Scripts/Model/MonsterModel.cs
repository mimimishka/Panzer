using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Panzer
{
    public class MonsterModel
    {
        public ReactiveProperty<float> Health { get; private set; }
        public ReactiveProperty<float> Damage { get; private set; }
        public ReactiveProperty<float> Protection { get; private set; }

        public MonsterModel(EnemyModelProto proto)
        {
            Health = new ReactiveProperty<float>(proto.Health);
            Damage = new ReactiveProperty<float>(proto.Damage);
            Protection = new ReactiveProperty<float>(proto.Protection);
        }
    }
}
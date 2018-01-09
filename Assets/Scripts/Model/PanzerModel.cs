using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Panzer
{
    public class PanzerModel
    {
        public PanzerModel()
        {
            GunId = new ReactiveProperty<int>(0);
            MaxHealth = new ReactiveProperty<float>();
            Health = new ReactiveProperty<float>();
            Protection = new ReactiveProperty<float>();
        }
        public ReactiveProperty<int> GunId { get; private set; }
        public ReactiveProperty<float> MaxHealth { get; private set; }
        public ReactiveProperty<float> Health { get; private set; }
        public ReactiveProperty<float> Protection { get; private set; }
    }
}
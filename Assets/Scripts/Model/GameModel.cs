using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Panzer
{
    public class GameModel
    {
        public ReactiveProperty<int> Score { get; private set; }
        public GameModel()
        {
            Score = new ReactiveProperty<int>();
        }
    }
}
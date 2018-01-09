using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Panzer
{
    public class TimerView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [SerializeField]
        float period = 0.3f;
        float nextTime = 0f;
        internal const string TICK = "tick";
        IObservable<long> ticker;
        internal void Init()
        {
            ticker = Observable.EveryFixedUpdate().Where(_ => Time.time >= nextTime);
            ticker.Subscribe(_ => OnTick());
        }
        internal void Stop()
        {
            nextTime = float.MaxValue;
        }
        void OnTick()
        {
            Dispatcher.Dispatch(TICK);
            nextTime = Time.time + period;
        }
    }
}
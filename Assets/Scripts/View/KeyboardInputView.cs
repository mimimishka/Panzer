using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UniRx;

namespace Panzer
{
    public class KeyboardInputView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }

        internal const string TURN_LEFT = "turn left";
        internal const string TURN_RIGHT = "turn right";
        internal const string DRIVE_FORWARD = "turn fwd";
        internal const string DRIVE_BACKWARD = "turn bckwd";
        internal const string ATTACK = "attack";
        internal const string NEXT_GUN = "next gun";
        internal const string PREV_GUN = "prev gun";

        internal void Init(InputControls controls)
        {
            SubscribeContinious(controls.TurnLeft, TURN_LEFT);
            SubscribeContinious(controls.TurnRight, TURN_RIGHT);
            SubscribeContinious(controls.DriveForward, DRIVE_FORWARD);
            SubscribeContinious(controls.DriveBackward, DRIVE_BACKWARD);

            SubscribeSingle(controls.PrevGun, PREV_GUN);
            SubscribeSingle(controls.NextGun, NEXT_GUN);
            SubscribeSingle(controls.Attack, ATTACK);
        }
        void SubscribeContinious(InputControl control, string eventId)
        {
            Observable.EveryFixedUpdate().Where(_ => Input.GetKey(control.Key))
                .Subscribe(_ => Dispatcher.Dispatch(eventId));
        }
        void SubscribeSingle(InputControl control, string eventId)
        {
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(control.Key))
                .Subscribe(_ => Dispatcher.Dispatch(eventId));
        }
    }
}
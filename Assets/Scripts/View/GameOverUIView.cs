using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Panzer
{
    public class GameOverUIView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }
        [SerializeField]
        GameObject panel;

        internal const string RESTART = "restart";
        internal const string CLOSE = "close";
        internal void Activate()
        {
            panel.SetActive(true);
        }
        public void Restart()
        {
            Dispatcher.Dispatch(RESTART);
        }
        public void Close()
        {
            Dispatcher.Dispatch(CLOSE);
        }
    }
}
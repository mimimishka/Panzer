using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Panzer
{
    public class ShellView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [SerializeField]
        GameObject particles;
        [SerializeField]
        Rigidbody rBody;
        public Rigidbody RBody { get { return rBody; } }
        public float Damage { get; set; }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
                return;
            MonsterView monster;
            if (monster = col.gameObject.GetComponent<MonsterView>())
                monster.ReceiveDamage(Damage);
            if (particles)
            {
                GameObject go = Instantiate(particles, transform.position, transform.rotation);
                Destroy(go, 1.5f);
            }
            Destroy(gameObject);
        }
    }
}
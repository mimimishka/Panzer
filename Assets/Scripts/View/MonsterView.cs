using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Panzer
{
    public class MonsterView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [SerializeField]
        Animator animator;
        [SerializeField]
        NavMeshAgent navMeshAgent;

        public NavMeshAgent NavAgent { get { return navMeshAgent; } }
        public MonsterModel Model { get; set; }

        //for animator
        const string WALK = "crippled";
        const string DEAD = "dead";

        //for dispatcher
        internal const string ON_HIT = "on hit";
        internal const string ON_DIE = "on die";

        public Transform Target { get; private set; }
        public bool Dead { get; private set; }

        internal void Init()
        {
            Dead = false;
            animator.SetBool(WALK, true);
            Target = FindObjectOfType<PanzerView>().transform;
        }

        public void ReceiveDamage(float dmg)
        {
            float? damage = dmg;
            Dispatcher.Dispatch(ON_HIT, damage);
        }
        internal void Stop()
        {
            //stop walking animation
            animator.SetBool(WALK, false);
        }
        internal void UpdateHealth(float h)
        {
            if (h == 0f)
                Die();
        }
        internal void Die()
        {
            StartCoroutine(Dying());
        }
        IEnumerator Dying()
        {
            Dead = true;
            navMeshAgent.isStopped = true;
            //set dying animation
            Stop();
            animator.SetBool(DEAD, true);
            yield return new WaitForSeconds(2f);
            Dispatcher.Dispatch(ON_DIE);
            Destroy(gameObject);
        }
    }
}
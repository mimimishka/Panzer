using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Panzer
{
    public class PanzerView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [SerializeField]
        Rigidbody rBody;
        [SerializeField]
        float acceleration = 5f;
        [SerializeField]
        float rotationSpeed = 10f;
        [SerializeField]
        float maxVelocity = 50f;
        [SerializeField]
        Transform turretMount;
        [SerializeField]
        GameObject particles;
        [SerializeField]
        AudioSource audioS;
        [SerializeField]
        AudioSource hitAudio;

        public Rigidbody RBody { get { return rBody; } }
        public float Acceleration { get { return acceleration; } }
        public float RotationSpeed { get { return rotationSpeed; } }
        public float MaxVelocity { get { return maxVelocity; } }
        public Transform TurretMount { get { return turretMount; } }

        public TurretView Turret { get; private set; }
        internal const string MONSTER_COL = "collision";

        internal void Init()
        {
            StartCoroutine(DriveSoundPlaying());
        }

        internal void MountTurret(TurretView turret)
        {
            if (Turret)
                Destroy(Turret.gameObject);
            this.Turret = Instantiate(turret.gameObject, turretMount).GetComponent<TurretView>();
        }
        internal void Die()
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(Turret.gameObject);
        }
        void OnCollisionEnter(Collision col)
        {
            MonsterView enemy = col.gameObject.GetComponent<MonsterView>();
            if (enemy && !enemy.Dead)
            {
                Dispatcher.Dispatch(MONSTER_COL, enemy);
                hitAudio.Play();
            }
        }
        IEnumerator DriveSoundPlaying()
        {
            while (true)
            {
                if (rBody.velocity.magnitude > 0 && !audioS.isPlaying)
                    audioS.Play();
                if (rBody.velocity.magnitude == 0f && audioS.isPlaying)
                    audioS.Stop();
                yield return null;
            }
        }
    }
}
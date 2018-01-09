using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Panzer
{
    public class TurretView : View
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; private set; }
        [SerializeField]
        Transform shellMount;
        [SerializeField]
        ShellView shellPrefab;
        [SerializeField]
        float shellInitForce = 500f;
        [SerializeField]
        float damage = 10f;
        [SerializeField]
        AudioSource audioS;

        public float Damage { get { return damage; } }

        internal void Shoot()
        {
            ShellView shell = Instantiate(shellPrefab.gameObject).GetComponent<ShellView>();
            shell.transform.localScale = new Vector3
            (
                shell.transform.localScale.x * shellMount.lossyScale.x,
                shell.transform.localScale.y * shellMount.lossyScale.y,
                shell.transform.localScale.z * shellMount.lossyScale.z
            );
            shell.transform.position = shellMount.position;
            shell.transform.rotation = shellMount.rotation;
            shell.RBody.AddForce(shell.transform.forward * shellInitForce);
            shell.Damage = damage;
            audioS.Play();
        }
    }
}
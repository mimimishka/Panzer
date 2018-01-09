using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class DrivePanzerCommand : Command
    {
        [Inject]
        public float Direction { get; private set; }
        public override void Execute()
        {
            PanzerView view = GameObject.FindObjectOfType<PanzerView>();
            if (!view)
            {
                Debug.LogError("Panzer not found");
                return;
            }
            view.RBody.AddForce(view.transform.forward * Direction * view.Acceleration);
            if (view.RBody.velocity.magnitude >= view.MaxVelocity)
                view.RBody.velocity = view.RBody.velocity.normalized * view.MaxVelocity;
        }
    }
}
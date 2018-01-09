using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class TurnPanzerCommand : Command
    {
        [Inject]
        public float Direction { get; private set; }
        [Inject(name = Error.VELOCITY)]
        public float VelError { get; private set; }
        public override void Execute()
        {
            PanzerView view = GameObject.FindObjectOfType<PanzerView>();
            if (!view)
            {
                Debug.LogError("panzer not found");
                return;
            }
            if (view.RBody.velocity.magnitude > VelError &&
                (-view.transform.forward - view.RBody.velocity).magnitude <
                (view.transform.forward - view.RBody.velocity).magnitude)
                Direction *= -1f;

            view.transform.Rotate(view.transform.up, Direction * view.RotationSpeed * Time.deltaTime);
        }
    }
}
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;

namespace Panzer
{
    public class RestartGameCommand : Command
    {
        public override void Execute()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
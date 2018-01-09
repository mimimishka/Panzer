using UnityEngine;
using strange.extensions.command.impl;

namespace Panzer
{
    public class CloseGameCommand : Command
    {
        public override void Execute()
        {
            Application.Quit();
        }
    }
}
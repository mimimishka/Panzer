using strange.extensions.context.impl;

namespace Panzer
{
    public class Root : ContextView
    {
        void Awake()
        {
            context = new MainContext(this);
        }
    }
}
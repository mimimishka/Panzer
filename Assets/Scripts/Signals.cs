using strange.extensions.signal.impl;

namespace Panzer
{
    public class StartAppSignal : Signal { }
    public class TurnPanzerSignal : Signal<float> { }
    public class DrivePanzerSignal : Signal<float> { }
    public class TurretChangeSignal : Signal<int> { }
    public class AttackSignal : Signal { }
    public class MonsterAttackedSignal : Signal<MonsterModel, float> { }
    public class MonsterDeficitSignal : Signal<int> { }
    public class TimeElapsedSignal : Signal { }
    public class MonsterDeadSignal : Signal { }
    public class PanzerAttackedSignal : Signal<MonsterView> { }
    public class GameOverSignal : Signal { }
    public class OnGameRestartSignal : Signal { }
    public class OnGameCloseSignal : Signal { }
}

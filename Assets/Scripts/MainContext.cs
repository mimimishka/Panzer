using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using UnityEngine;

namespace Panzer
{
    public class MainContext : MVCSContext
    {
        public MainContext(MonoBehaviour view) : base(view) { }
        public MainContext(MonoBehaviour view, ContextStartupFlags flags) : base (view, flags) { }
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>();
        }
        protected override void mapBindings()
        {
            base.mapBindings();
            SignalBindings();
            CommandBindings();
            InjectionBindings();
            MediationBindings();
            ResourcesBindings();
        }

        public override void Launch()
        {
            injectionBinder.GetInstance<StartAppSignal>().Dispatch();
        }
        void InjectionBindings()
        {
            injectionBinder.Bind<PanzerModel>().ToSingleton();
            injectionBinder.Bind<GameModel>().ToSingleton();
            injectionBinder.Bind<int>().ToValue(1).ToName(MonsterValue.MONSTER_INC);
            injectionBinder.Bind<int>().ToValue(10).ToName(MonsterValue.MONSTER_INIT);
            injectionBinder.Bind<float>().ToValue(0.1f).ToName(Error.VELOCITY);
        }
        void CommandBindings()
        {
            commandBinder.Bind<StartAppSignal>().To<InitGameCommand>();
            commandBinder.Bind<TurretChangeSignal>().To<ChangeTurretCommand>();
            commandBinder.Bind<MonsterDeficitSignal>().To<CreateMonstersCommand>();
            commandBinder.Bind<MonsterAttackedSignal>().To<DamageMonsterCommand>();
            commandBinder.Bind<DrivePanzerSignal>().To<DrivePanzerCommand>();
            commandBinder.Bind<TurnPanzerSignal>().To<TurnPanzerCommand>();
            commandBinder.Bind<TimeElapsedSignal>().To<MakeAIDecisionCommand>();
            commandBinder.Bind<MonsterDeadSignal>().To<IncreaseScoreCommand>();
            commandBinder.Bind<PanzerAttackedSignal>().To<DamagePanzerCommand>();
            commandBinder.Bind<GameOverSignal>().To<GameOverCommand>();
            commandBinder.Bind<OnGameCloseSignal>().To<CloseGameCommand>();
            commandBinder.Bind<OnGameRestartSignal>().To<RestartGameCommand>();
        }
        void SignalBindings()
        {
            injectionBinder.Bind<TurnPanzerSignal>().ToSingleton();
            injectionBinder.Bind<DrivePanzerSignal>().ToSingleton();
            injectionBinder.Bind<TurretChangeSignal>().ToSingleton();
            injectionBinder.Bind<AttackSignal>().ToSingleton();
            injectionBinder.Bind<MonsterDeficitSignal>().ToSingleton();
            injectionBinder.Bind<MonsterAttackedSignal>().ToSingleton();
            injectionBinder.Bind<TimeElapsedSignal>().ToSingleton();
            injectionBinder.Bind<MonsterDeadSignal>().ToSingleton();
            injectionBinder.Bind<PanzerAttackedSignal>().ToSingleton();
            injectionBinder.Bind<GameOverSignal>().ToSingleton();
            injectionBinder.Bind<OnGameCloseSignal>().ToSingleton();
            injectionBinder.Bind<OnGameRestartSignal>().ToSingleton();
        }
        void MediationBindings()
        {
            mediationBinder.Bind<PanzerView>().To<PanzerMediator>();
            mediationBinder.Bind<KeyboardInputView>().To<KeyboardInputMediator>();
            mediationBinder.Bind<TurretView>().To<TurretMediator>();
            mediationBinder.Bind<MonsterView>().To<MonsterMediator>();
            mediationBinder.Bind<TimerView>().To<TimerMediator>();
            mediationBinder.Bind<PlayerUIView>().To<PlayerUIMediator>();
            mediationBinder.Bind<GameOverUIView>().To<GameOverUIMediator>();
        }
        void ResourcesBindings()
        {
            injectionBinder.Bind<InputControls>().ToValue
            (
                Resources.Load("Inputs") as InputControls
            );
            injectionBinder.Bind<TurretsSet>().ToValue
            (
                Resources.Load("Turrets") as TurretsSet
            );
            injectionBinder.Bind<EnemiesConfig>().ToValue
            (
                Resources.Load("EnemiesConfig") as EnemiesConfig
            );
            injectionBinder.Bind<SpawPointsSet>().ToValue
            (
                Resources.Load("SpawnSet") as SpawPointsSet
            );
            injectionBinder.Bind<PanzerConfig>().ToValue
            (
                Resources.Load("PanzerConfig") as PanzerConfig
            );
        }
    }
}
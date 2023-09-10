using JetBrains.Annotations;
using Runer;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Runer.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private TraceSettings traceSettings;

        [SerializeField] private SwipeDetector inputSystem;
        [SerializeField] private PlayerCollisionDetector playerCollisionDetector;

        public override void InstallBindings()
        {
            Container.Bind<MovementSettings>().FromInstance(movementSettings).AsSingle();
            Container.Bind<TraceSettings>().FromInstance(traceSettings).AsSingle();
            Container.Bind<SwipeDetector>().FromInstance(inputSystem).AsSingle();
            Container.Bind<IDefeatSender>().To<PlayerCollisionDetector>().FromInstance(playerCollisionDetector).AsSingle();

            Container.Bind<PlayerMovementState>().FromNew().AsSingle();
            Container.Bind<MatchModel>().FromNew().AsSingle();
        }
    }
}
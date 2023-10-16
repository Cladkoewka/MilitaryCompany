using Assets.CodeBase.Architecture.AssetManagement;
using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Architecture.GameStates;
using Assets.CodeBase.Services.CombatService;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.SaveLoad;
using Assets.CodeBase.Services.StaticData;
using Zenject;

namespace Assets.CodeBase.Architecture.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();                                                                 
            Container.Bind<ICoroutineRunner>().To<GameBootstrapper>().FromComponentInHierarchy().AsSingle(); 
            Container.Bind<GameStateMachine>().AsSingle();

            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ICombatService>().To<CombatService>().AsSingle();
        }
    }
}
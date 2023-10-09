using Assets.CodeBase.Services.CombatService;
using Zenject;

namespace Assets.CodeBase.Architecture.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().To<GameBootstrapper>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ICombatService>().To<CombatService>().AsSingle();
            Container.Bind<Game>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}
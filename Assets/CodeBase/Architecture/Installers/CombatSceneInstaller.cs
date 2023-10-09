using Assets.CodeBase.Services.CombatService;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Architecture.Installers
{
    public class CombatSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Installing");
            Container.Bind<ICombatService>().To<CombatService>().AsSingle();
            Debug.Log("End Installing");
        }
    }
}

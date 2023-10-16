using System.Collections.Generic;
using Assets.CodeBase.Architecture.AssetManagement;
using Assets.CodeBase.GameLogic.Units;
using Assets.CodeBase.GameLogic.UnitSpawners;
using Assets.CodeBase.Services.CombatService;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.Services.StaticData;
using Assets.CodeBase.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Architecture.Factory
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        
        private readonly IStaticDataService _staticData;
        private readonly ICombatService _combatService;
        private readonly IAssetProvider _assets;

        
        public GameFactory(IAssetProvider assets, IStaticDataService staticData, ICombatService combatService)
        {
            _assets = assets;
            _staticData = staticData;
            _combatService = combatService;
        }
        
        public GameObject CreateUnit(UnitTypeId typeId, Transform parent)
        {
            UnitStaticData unitData = _staticData.ForUnit(typeId);
            GameObject unit = Object.Instantiate(unitData.Prefab, parent.position, Quaternion.identity, parent);
            
            IHealth health = unit.GetComponent<IHealth>();
            health.MaxHealth = unitData.Hp;
            health.CurrentHealth = unitData.Hp;
            
            unit.GetComponent<NavMeshAgent>().speed = unitData.MoveSpeed;
            UnitAttack attack = unit.GetComponent<UnitAttack>();
            attack.Damage = unitData.Damage;
            attack.EffectiveDistance = unitData.EffectiveDistance;
            
            _combatService.AddUnit(unit.GetComponent<Unit>());
            unit.GetComponent<UnitAttack>().Construct(_combatService);
            unit.GetComponent<UnitDeath>().Construct(_combatService);
            unit.GetComponent<AgentMoveToTarget>().Construct(_combatService);

            return unit;
        }

        public void CreateSpawner(string spawnerId, Vector3 at, UnitTypeId unitTypeId)
        {
            SpawnPoint spawner = InstantiateRegistered(AssetPath.Spawner, at).GetComponent<SpawnPoint>();
            
            spawner.Construct(this);
            spawner.UnitTypeId = unitTypeId;
            spawner.Id = spawnerId;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
        
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath, at: at);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }
        
        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }
        
        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}
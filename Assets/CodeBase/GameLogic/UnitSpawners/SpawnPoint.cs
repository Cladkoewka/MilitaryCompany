using Assets.CodeBase.Architecture.Factory;
using Assets.CodeBase.Data;
using Assets.CodeBase.GameLogic.Units;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.UnitSpawners
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        public UnitTypeId UnitTypeId;
        
        public string Id { get; set; }

        private IGameFactory _gameFactory;
        
        private UnitDeath _unitDeath;
        
        private bool _slain;
        
        //[Inject]
        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void OnDestroy()
        {
            if (_unitDeath != null)
                _unitDeath.Died -= Slay;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            
        }

        private void Spawn()
        {
            GameObject monster = _gameFactory.CreateUnit(UnitTypeId, transform);
            _unitDeath = monster.GetComponent<UnitDeath>();
            _unitDeath.Died += Slay;
        }

        private void Slay(Unit unit)
        {
            if (_unitDeath != null)
                _unitDeath.Died -= Slay;
      
            _slain = true;
        }
    }
}
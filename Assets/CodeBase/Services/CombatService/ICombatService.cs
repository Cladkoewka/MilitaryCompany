using System.Collections.Generic;
using Assets.CodeBase.GameLogic.Units;
using UnityEngine;

namespace Assets.CodeBase.Services.CombatService
{
    public interface ICombatService
    {
        public Unit FindNearestTarget(Unit unit);
        public List<Unit> GetEnemyUnits();
        public List<Unit> GetPlayerUnits();
        public void RemoveUnit(Unit unitToRemove);
        public void AddUnit(Unit unit);



    }
}
using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.GameLogic.Units;
using UnityEngine;

namespace Assets.CodeBase.Services.CombatService
{
    public class CombatService : MonoBehaviour, ICombatService
    {
        private List<Unit> _allUnits = new List<Unit>();
        
        public Unit FindNearestTarget(Unit unit)
        {
            List<Unit> unitsToSearch = new List<Unit>();
            if (unit.GetComponent<PlayerUnit>())
            {
                unitsToSearch = GetEnemyUnits();
            }
            else
            {
                unitsToSearch = GetPlayerUnits();
            }
            return FindNearestTarget(unit.transform.position, unitsToSearch);
        }

        public List<Unit> GetEnemyUnits()
        {
            List<Unit> enemyUnits = _allUnits.Where(unit => unit is EnemyUnit).ToList();
            return enemyUnits;
        }

        public List<Unit> GetPlayerUnits()
        {
            List<Unit> playerUnits = _allUnits.Where(unit => unit is PlayerUnit).ToList();
            return playerUnits;
        }
        
        public void AddUnit(Unit unit)
        {
            _allUnits.Add(unit);
        }
        
        public void RemoveUnit(Unit unitToRemove)
        {
            if (_allUnits.Contains(unitToRemove))
            {
                _allUnits.Remove(unitToRemove);
            }
        }

        private Unit FindNearestTarget(Vector3 position, List<Unit> unitsToSearch)
        {
            Unit nearestTarget = null;
            float minDistance = Mathf.Infinity;

            foreach (Unit unit in unitsToSearch)
            {
                float distance = Vector3.Distance(position, unit.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTarget = unit;
                }
            }

            return nearestTarget;
        }
    }
}
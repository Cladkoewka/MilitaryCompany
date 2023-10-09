using Assets.CodeBase.Services.CombatService;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Units
{
    public class Unit : MonoBehaviour
    {
        private void Start()
        {
            // Получите ссылку на CombatService, например, с помощью FindObjectOfType
            CombatService combatService = FindObjectOfType<CombatService>();

            // Если combatService не равен null, добавьте этот юнит в список
            if (combatService != null)
            {
                combatService.AddUnit(this);
            }
        }
    }
}
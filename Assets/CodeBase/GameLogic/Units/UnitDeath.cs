using System;
using System.Collections;
using Assets.CodeBase.Services.CombatService;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Units
{
    [RequireComponent(typeof(UnitHealth), typeof(Unit))]
    public class UnitDeath: MonoBehaviour
    {
        public UnitHealth Health;

        public event Action<Unit> Died;
        

        private ICombatService _combatService;

        public void Construct(ICombatService combatService)
        {
            _combatService = combatService;
        }
        
        private void Start()
        {
            Health.HealthChanged += OnHealthChanged;
            //_combatService = FindObjectOfType<CombatService>();
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (Health.CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Health.HealthChanged -= OnHealthChanged;
            StartCoroutine(DestroyTimer());
            _combatService.RemoveUnit(this.GetComponent<Unit>());
      
            Died?.Invoke(this.GetComponent<Unit>());
        }
        
        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0);
            Destroy(gameObject);
        }
    }
}
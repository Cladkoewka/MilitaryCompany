using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.Services.CombatService;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Units
{
    public class UnitAttack : MonoBehaviour
    {
        public float AttackCooldown = 3.0f;
        public float Cleavage = 0.5f;
        public float EffectiveDistance = 0.5f;
        public float Damage = 10;

        private float _attackCooldown;
        private bool _isAttacking = false;
        private bool _attackIsActive = true;
        
        
        private ICombatService _combatService;

        public void Construct(ICombatService combatService)
        {
            _combatService = combatService;
        }

        private void Update()
        {
            UpdateCooldown();

            if(CanAttack())
                StartAttack();
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }
        
        private bool CooldownIsUp() => 
            _attackCooldown <= 0f;
        
        private bool CanAttack() => 
            _attackIsActive && !_isAttacking && CooldownIsUp();
        
        private void StartAttack()
        {
            Debug.Log(_combatService);
            Unit targetToAttack = _combatService.FindNearestTarget(this.GetComponent<Unit>());
            if (targetToAttack)
            {
                transform.LookAt(targetToAttack.transform);
                targetToAttack.GetComponent<IHealth>().TakeDamage(Damage);
            }
            _attackCooldown = AttackCooldown;
        }
    }
}
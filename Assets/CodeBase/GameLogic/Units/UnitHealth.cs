using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Units
{
    public class UnitHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _currentHealth;
        [SerializeField] private float _maxHealth;
        
        public event Action HealthChanged;
        
        public float MaxHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
        public float CurrentHealth 
        { 
            get => _maxHealth;
            set => _maxHealth = value; 
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            
            HealthChanged?.Invoke();
        }
    }
}
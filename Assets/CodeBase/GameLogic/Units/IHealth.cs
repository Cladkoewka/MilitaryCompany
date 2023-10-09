using System;

namespace Assets.CodeBase.GameLogic.Units
{
    public interface IHealth
    {
        event Action HealthChanged;
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public void TakeDamage(float damage);
    }
}
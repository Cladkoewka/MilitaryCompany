using UnityEngine;

namespace Assets.CodeBase.GameLogic.Units
{
    public class UnitAnimator : MonoBehaviour
    {
        private const string Takedamage = "TakeDamage";
        private const string Attack = "Attack";
        private const string Death = "Death";
        private const string Ismoving = "IsMoving";
        
        [SerializeField]
        private Animator _animator;

        public enum UnitState
        {
            Idle,
            Move,
            Attack,
            TakeDamage,
            Dead
        }

        private UnitState _currentState;


        public void SetMoveAnimation(bool isMoving)
        {
            _animator.SetBool(Ismoving, isMoving);
        }

        public void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayTakingDamageAnimation()
        {
            _animator.SetTrigger(Takedamage);
        }

        public void PlayDeathAnimation()
        {
            _animator.SetBool(Death, true);
        }
    }
}
using Assets.CodeBase.Data;
using Assets.CodeBase.Services.CombatService;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.GameLogic.Units
{
    public class AgentMoveToTarget : MonoBehaviour
    {
        public NavMeshAgent Agent;
        
        private const float MinimalDistance = 1;

        private Unit _target;
        
        private ICombatService _combatService;

        /*[Inject]
        private void Construct(ICombatService combatService)
        {
            Debug.Log("UnitAttackInject");
            _combatService = combatService;
        }*/
        
        private void Start()
        {
            _combatService = FindObjectOfType<CombatService>();
        }
        
        private void Update()
        {
            if (!_target)
            {
                _target = _combatService.FindNearestTarget(this.GetComponent<Unit>());
            }
            if(_target && IsHeroNotReached())
                Agent.destination = _target.transform.position - (_target.transform.position - transform.position).normalized * 3f;
        }
    
        private bool IsHeroNotReached() => 
            Agent.transform.position.SqrMagnitudeTo(_target.transform.position) >= MinimalDistance;
    }
}
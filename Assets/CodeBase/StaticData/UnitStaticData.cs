using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Static Data/Unit")]
    public class UnitStaticData : ScriptableObject
    {
        public UnitTypeId UnitTypeId;
        
        [Range(1,500)]
        public float Hp = 50;
    
        [Range(1,100)]
        public float Damage = 10;
        
        [Range(.5f,100)]
        public float EffectiveDistance = .5f;

        [Range(0,10)]
        public float MoveSpeed = 3;
        
        public GameObject Prefab;
    }
}
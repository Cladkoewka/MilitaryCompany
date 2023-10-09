using UnityEngine;

namespace Assets.CodeBase.GameLogic.Units
{
    [CreateAssetMenu(fileName = "UnitData",  menuName = "Data/UnitData")]
    public class UnitData : ScriptableObject
    {
        [Range(1, 500)] public int MaxHp;
        [Range(0, 100)] public int Damage;
        [Range(0.1f, 10)]public float AttackDelay;
    }
}
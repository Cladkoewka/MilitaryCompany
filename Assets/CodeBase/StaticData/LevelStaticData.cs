using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<UnitSpawnerStaticData> UnitSpawners;
    }
}
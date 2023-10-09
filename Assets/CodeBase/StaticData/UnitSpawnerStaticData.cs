using System;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [Serializable]
    public class UnitSpawnerStaticData
    {
        public string Id;
        public UnitTypeId MonsterTypeId;
        public Vector3 Position;

        public UnitSpawnerStaticData(string id, UnitTypeId monsterTypeId, Vector3 position)
        {
            Id = id;
            MonsterTypeId = monsterTypeId;
            Position = position;
        }
    }
}
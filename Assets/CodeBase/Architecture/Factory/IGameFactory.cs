using Assets.CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Architecture.Factory
{
    public interface IGameFactory
    {
        GameObject CreateUnit(UnitTypeId typeId, Transform parent);
        void CreateSpawner(string spawnerId, Vector3 at, UnitTypeId monsterTypeId);
        void Cleanup();
    }
}
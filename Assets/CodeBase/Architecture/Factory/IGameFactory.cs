using System.Collections.Generic;
using Assets.CodeBase.Services;
using Assets.CodeBase.Services.PersistentProgress;
using Assets.CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Architecture.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        GameObject CreateUnit(UnitTypeId typeId, Transform parent);
        void CreateSpawner(string spawnerId, Vector3 at, UnitTypeId unitTypeId);
        void Cleanup();
    }
}
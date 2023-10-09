using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.Architecture.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}
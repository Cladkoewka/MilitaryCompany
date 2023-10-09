using Assets.CodeBase.StaticData;

namespace Assets.CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        UnitStaticData ForUnit(UnitTypeId typeId);
        LevelStaticData ForLevel(string sceneKey);
    }
}
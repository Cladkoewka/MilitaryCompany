using System.Linq;
using System.Xml;
using Assets.CodeBase.GameLogic.UnitSpawners;
using Assets.CodeBase.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                levelData.UnitSpawners = FindObjectsOfType<SpawnMarker>()
                    .Select(x => new UnitSpawnerStaticData("x.GetComponent<UniqueId>().Id", x.UnitTypeId, x.transform.position))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }
      
            EditorUtility.SetDirty(target);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Biorama.Essentials
{
    public enum SceneType
    {
        MainScene,
        PlayScene
    }

    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/SceneManager", fileName = "SceneManager")]
    public class CustomSceneManager : ScriptableObject
    {
        public SerializableDictionary<SceneType, string> sceneDataSet = new SerializableDictionary<SceneType, string>();
        

        public void LoadScene(SceneType aSceneType)
        {
            SceneManager.LoadScene(sceneDataSet[aSceneType]);
        }
    }
}

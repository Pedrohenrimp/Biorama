using System.IO;
using UnityEditor;
using UnityEngine;

namespace Biorama.Essentials
{
    public static class JsonUtils
    {
        public static T ParseToObject<T>(TextAsset aJsonData)
        {
            T obj = JsonUtility.FromJson<T>(aJsonData.text);
            return obj;
        }

        public static void ParseToJson<T>(T aObject, TextAsset aJsonData)
        {
            var json = JsonUtility.ToJson(aObject);
            File.WriteAllText(AssetDatabase.GetAssetPath(aJsonData), json);
        }
    }
}

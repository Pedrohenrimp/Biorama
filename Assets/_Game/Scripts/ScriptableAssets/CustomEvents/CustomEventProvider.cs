using UnityEngine;

namespace Biorama.Events
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Providers/CustomEventProvider", fileName = "CustomEventProvider")]
    public class CustomEventProvider : ScriptableObject
    {
        public SerializableDictionary<string, BaseCustomEvent> eventDataSet = new SerializableDictionary<string, BaseCustomEvent>();

        public BaseCustomEvent GetEvent(string aKey)
        {
            return eventDataSet[aKey];
        }
    }
}

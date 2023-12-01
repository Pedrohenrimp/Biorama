using System;
using UnityEngine;

namespace Biorama.Events
{
    [CreateAssetMenu(menuName = "Biorama/ScriptableAssets/Events/TransformEvent", fileName = "TransformEvent")]
    public class TransformEvent : BaseCustomTypeEvent<Transform>
    {
    }
}

using System;
using UnityEngine;

namespace Biorama.Essentials
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CustomNameAttribute : PropertyAttribute
    {
        private string mCustomName;
        public string CustomName => mCustomName;

        public CustomNameAttribute(string aName)
        {
            mCustomName = aName;
        }
    }
}
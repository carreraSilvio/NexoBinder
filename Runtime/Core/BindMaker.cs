using System;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
    public class BindMaker
    {
        public MonoBehaviour _targetMonoBehaviour;
        public string _targetFieldName;
    }
}
using System;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
    public abstract class Binder : MonoBehaviour
    {
        public MonoBehaviour _targetMonoBehaviour;
        public string _targetMemberName;
    }
}
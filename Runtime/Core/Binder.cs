using System;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
    public abstract class Binder<T> : MonoBehaviour where T : BinderData
    {
        public MonoBehaviour targetMonoBehaviour;
        public string targetMemberName;

        public T data;
    }

    [Serializable]
    public class BinderData
    {
        public MonoBehaviour targetMonoBehaviour;
        public string targetMemberName;
    }
}
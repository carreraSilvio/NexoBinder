using System;
using UnityEngine;

namespace NexoBinder.Runtime
{
    [Serializable]
    public abstract class Binder<T> : MonoBehaviour where T : BinderData
    {
        public MonoBehaviour TargetMonoBehaviour
        {
            get
            {
                return data.targetMonoBehaviour;
            }
            set
            {
                data.targetMonoBehaviour = value;
            }
        }

        public string TargetMemberName
        {
            get
            {
                return data.targetMemberName;
            }
            set
            {
                data.targetMemberName = value;
            }
        }

        public T data;
    }

    [Serializable]
    public class BinderData
    {
        public MonoBehaviour targetMonoBehaviour;
        public string targetMemberName;
    }
}
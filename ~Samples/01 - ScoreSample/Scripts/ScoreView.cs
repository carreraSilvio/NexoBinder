using NexoBinder.Runtime.Core;
using UnityEngine;

namespace NexoBinder.Samples
{
    [BindableTarget]
    public class ScoreView : MonoBehaviour
    {
        public BindableField<int> score;
    }
}
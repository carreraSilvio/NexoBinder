using System;
using UnityEngine;

public class View<T> : MonoBehaviour 
{
    public Action<T> OnSet;
}

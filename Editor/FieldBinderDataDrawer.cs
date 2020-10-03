using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using NexoBinder.Runtime.Core;
using System.Reflection;

namespace NexoBinder.Editor
{
    [CustomPropertyDrawer(typeof(FieldBinderData))]
    public class FieldBinderDataDrawer : BinderDataDrawer<FieldBinderData>
    {
        protected override string BinderTypeName => "Field";

        protected override void GetOptions(SerializedProperty property)
        {
            _binderList.Clear();
            _binderList.Add(new BinderData());

            MonoBehaviour targetObjectMonoBehaviour = (MonoBehaviour)property.serializedObject.targetObject;
            Transform targetObjectTransform = targetObjectMonoBehaviour.transform;

            List<MonoBehaviour> propertyFieldOwners = new List<MonoBehaviour>
            {
                targetObjectMonoBehaviour
            };

            targetObjectTransform.GetComponentsInParent(true, propertyFieldOwners);

            Type propType = typeof(BindableField);

            foreach (var obj in propertyFieldOwners)
            {
                Type objType = obj.GetType();

                if (objType.IsDefined(typeof(BindableTargetAttribute), true))
                {
                    FieldInfo[] fieldInfoArray = objType.GetFields(FIELD_FLAGS);
                    foreach (FieldInfo fieldInfo in fieldInfoArray)
                    {
                        if (IsAssignableFromAnyOf(fieldInfo.FieldType, propType) ||
                            fieldInfo.FieldType == propType)
                        {
                            _binderList.Add(new BinderData()
                            {
                                targetMonoBehaviour = obj,
                                targetMemberName = fieldInfo.Name
                            });
                        }
                    }
                }
            }
        }

        public static bool IsAssignableFromAnyOf(Type givenType, Type genericType)
        {
            Type baseType = givenType.BaseType;

            if (baseType == null)
            {
                return false;
            }

            if (baseType == genericType)
            {
                return true;
            }

            return IsAssignableFromAnyOf(baseType, genericType);
        }
    }
}


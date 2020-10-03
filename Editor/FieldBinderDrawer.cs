using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using NexoBinder.Runtime.Core;

namespace NexoBinder.Editor
{
	//[CustomPropertyDrawer(typeof(BinderData))]
	//public class FieldBinderDrawer : BinderDrawer<FieldBinder>
	//{
	//	protected override string BinderTypeName => "Field";

	//	protected override void GetOptions(SerializedProperty property)
	//	{
	//		_binderList.Clear();
	//		_binderList.Add(new BinderData());

	//		var target = (MonoBehaviour)property.serializedObject.targetObject;

	//		var binderTransform = target.transform;

	//		List<MonoBehaviour> propertyFieldOwners = new List<MonoBehaviour>();

	//		propertyFieldOwners.Add(target);

	//		binderTransform.GetComponentsInParent(true, propertyFieldOwners);

	//		var propType = typeof(BindableField);

	//		foreach (var obj in propertyFieldOwners)
	//		{
	//			var objType = obj.GetType();

	//			if (objType.IsDefined(typeof(BindableTargetAttribute), true))
	//			{
	//				var fields = objType.GetFields(FIELD_FLAGS);
	//				foreach (var field in fields)
	//				{
	//					if (IsAssignableFromAnyOf(field.FieldType, propType) ||
	//						field.FieldType == propType)
	//					{
 //                           _binderList.Add(new BinderData()
 //                           {
 //                               targetMonoBehaviour = obj,
 //                               targetMemberName = field.Name
 //                           });
 //                       }
	//				}
	//			}
	//		}
	//	}

	//	public static bool IsAssignableFromAnyOf(Type givenType, Type genericType)
	//	{
	//		Type baseType = givenType.BaseType;

	//		if (baseType == null)
	//			return false;

	//		if (baseType == genericType) return true;

	//		return IsAssignableFromAnyOf(baseType, genericType);
	//	}

		//protected override string GetOptionName(Binder binder)
		//{
		//	if (binder.m_TargetObject == null) return "None";
		//	var objType = binder.m_TargetObject.GetType();
		//	return $"({binder.m_TargetObject.name}) {binder.m_TargetObject.GetType().Name} / {binder.m_TargetMember}";
		//}
	//}
}


using System;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public static class TransformExtensions
{
    public static Transform FindRecursive(this Transform self, string exactName) => self.FindRecursive(child => child.name == exactName);

    public static Transform FindRecursive(this Transform self, Func<Transform, bool> selector)
    {
        foreach (Transform child in self)
        {
            if (selector(child))
            {
                return child;
            }

            var finding = child.FindRecursive(selector);

            if (finding != null)
            {
                return finding;
            }
        }

        return null;
    }

    public static void SetHierarchyActive(this GameObject gameObject, bool active)
    {
        gameObject.SetActive(active);

        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetHierarchyActive(active);
        }
    }
}

//public static class ObjectManipulatorExtensions
//{
//    public static GameObject AddObjectManipulator_OnStarted_Listener(this GameObject self, Func<ObjectManipulator, bool> ) => self.AddObjectManipulator_OnStarted_Listener(child => child.name == exactName);

//    public static GameObject AddObjectManipulator_OnStarted_Listener(this GameObject self, Func<ObjectManipulator, bool> selector)
//    {

//        foreach (ObjectManipulator obj_manipulator in self.GetComponentsInChildren<ObjectManipulator>())
//        {
//            if (selector(obj_manipulator))
//            {
//                return obj_manipulator;
//            }
//            obj_manipulator.OnManipulationStarted.AddListener(DestroyInteractableHierarchy);

//            var finding = obj_manipulator.AddObjectManipulator_OnStarted_Listener(selector);

//            if (finding != null)
//            {
//                return finding;
//            }
//        }

//        return null;
//    }
//}
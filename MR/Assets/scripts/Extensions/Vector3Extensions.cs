using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 GetRotatedPointAroundPivot(this Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        return RotatePointAroundPivot(point, pivot, rotation);
    }
    public static Vector3 GetRotatedPointAroundPivot(this Vector3 point, Quaternion rotation)
    {
        return RotatePointAroundPivot(point, Vector3.zero, rotation);
    }
    public static void RotateAroundPivot(this Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        point = RotatePointAroundPivot(point, pivot, rotation);
        //point = rotation * (point - pivot) + pivot;
    }
    //public static Vector3 RotatePointAroundPivot(this Vector3 self, Vector3 point, Vector3 pivot, Vector3 eulerAngles);
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 eulerAngles)
    {
        return RotatePointAroundPivot(point, pivot, Quaternion.Euler(eulerAngles));
    }
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
    {
        // @aldonatello: https://answers.unity.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        //Vector3 direction = point - pivot; // get point direction relative to pivot
        //direction = rotation * direction; // rotate it
        //point = direction + pivot;
        return rotation * (point - pivot) + pivot; // calculate rotated point and return it
    }

    //public static void RotatePosAroundPivot(this Pose self, Vector3 pivot, Quaternion rotation)
    //{
    //    self.position = self.position.RotateAroundPivot(pivot, rotation);
    //}
}

//public static class Vector3Extensions
//{
//    public static Vector3 SetX(this Vector3 pos, float x)
//    {
//        return new Vector3(x, pos.y, pos.z);
//    }
//}
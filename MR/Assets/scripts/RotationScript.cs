using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
     
    public GameObject objectToRotate;
    public GameObject cubeX;
    public GameObject cubeY;
    public GameObject cubeZ;

    private Quaternion initialRotationX;
    private Quaternion initialRotationY;
    private Quaternion initialRotationZ;

    // Start is called before the first frame update
    void Start()
    {
        initialRotationX = cubeX.transform.localRotation;
        initialRotationY = cubeY.transform.localRotation;
        initialRotationZ = cubeZ.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion relativeRotationX = Quaternion.Inverse(initialRotationX) * cubeX.transform.localRotation;
        Quaternion relativeRotationY = Quaternion.Inverse(initialRotationY) * cubeY.transform.localRotation;
        Quaternion relativeRotationZ = Quaternion.Inverse(initialRotationZ) * cubeZ.transform.localRotation;

        Quaternion combinedRotation = relativeRotationX * relativeRotationY * relativeRotationZ;

        objectToRotate.transform.localRotation = combinedRotation;
    }
}
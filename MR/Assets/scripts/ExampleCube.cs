using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ExampleCube : MonoBehaviour
{
    public GameObject cube;

    // Update is called once per frame
    private void Update()
    {
        Vector3 cubeRotation = cube.transform.localEulerAngles;

        transform.localRotation = Quaternion.Euler(cubeRotation.x, 65, 0);
    }
}
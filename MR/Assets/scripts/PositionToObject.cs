using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionToObject : MonoBehaviour
{

    public Transform trackedTransform;

    private Transform initialTransform;
    // Start is called before the first frame update
    void Start()
    {
        initialTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = trackedTransform.position;
        transform.rotation = trackedTransform.rotation;
    }

    public void ResetTransform() { 
        transform.position = initialTransform.position;
        transform.rotation = initialTransform.rotation; 
    }
}

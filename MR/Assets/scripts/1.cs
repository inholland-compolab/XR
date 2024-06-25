using UnityEngine;

public class NoScaleDuringPlaytime : MonoBehaviour
{
    private Vector3 initialScale;

    void Start()
    {
        // Save the initial scale of the GameObject
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Check if the current scale is different from the initial scale
        if (transform.localScale != initialScale)
        {
            // If different, revert to the initial scale
            transform.localScale = initialScale;
        }
    }
}


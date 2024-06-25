using UnityEngine;

public class DisappearObjectAfterAppearance : MonoBehaviour
{
    private bool hasAppeared = false;

    // Public variable to set the delay time in the Unity editor
    public float delayTime = 8f;

    void Update()
    {
        // Check if the gameObject has appeared
        if (!hasAppeared)
        {
            Debug.Log("Object has appeared!");

            // Set the flag to true once the gameObject has appeared
            hasAppeared = true;

            // Invoke the method to make the gameObject disappear after the specified delay time
            Invoke("DisappearObject", delayTime);
        }
    }

    // Make the function public so it can be called from the button's OnClick event
    public void DisappearObject()
    {
        // Make the gameObject disappear
        Debug.Log("Object is disappearing now!");
        gameObject.SetActive(false);
    }
}

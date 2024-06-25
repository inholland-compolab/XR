using UnityEngine;

public class ObjectVisibilityController1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initially show the object the script is attached to
        gameObject.SetActive(true);
    }

    // Function to be called on button click
    public void ToggleObjectVisibility()
    {
        // Toggle the visibility of the object the script is attached to
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

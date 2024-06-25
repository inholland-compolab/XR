using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the object the script is attached to
        gameObject.SetActive(false);
    }

    // Function to be called on button click
    public void ToggleObjectVisibility()
    {
        // Toggle the visibility of the object the script is attached to
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

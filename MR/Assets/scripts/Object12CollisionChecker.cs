using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  
    public GameObject DesiredPoint;
    public GameObject TextToAppear;

    private void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        // Check if both Objects are touching
        if (gameObject.GetComponent<Collider>().bounds.Intersects(DesiredPoint.GetComponent<Collider>().bounds))
        {
            // If colliding, make TextToAppear active in scene
            TextToAppear.SetActive(true);
        }
        else
        {
            // If not colliding, make TextToAppear inactive in scene
            TextToAppear.SetActive(false);
        }
    }
}


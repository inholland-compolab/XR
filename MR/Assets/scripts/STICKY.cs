using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class STICKY : MonoBehaviour
{

    public string StuckObjectTag = "Wall";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(StuckObjectTag))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
   
}

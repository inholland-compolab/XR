using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float maxRotationAngle = 30f;
    private bool rotationDisabled = false;
    private Rigidbody rigidbody;
    private Quaternion initialRotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (!rotationDisabled)
        {
            float deltaZRotation = Quaternion.Angle(initialRotation, transform.rotation);

            if (deltaZRotation >= maxRotationAngle)
            {
                DisableRotation();
            }
        }
    }

    void DisableRotation()
    {
        rotationDisabled = true;
        rigidbody.freezeRotation = true;
        Debug.Log("Rotation disabled!");
    }
}




using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 1.0f; // Adjust the jump speed in the Inspector

    private bool isJumping = false;
    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        float newY = Mathf.PingPong(Time.time * jumpSpeed, 1f) * 0.11f; // Multiply by jumpSpeed
        transform.position = new Vector3(transform.position.x, newY + initialY, transform.position.z);
    }

    public void OnJumpButtonPressed()
    {
        isJumping = !isJumping;
    }
}

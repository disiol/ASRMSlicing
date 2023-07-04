using UnityEngine;

public class CupMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust this value to control the speed of the cup
    public float movementRange = 5f; // Adjust this value to control the range of cup movement
    public float frequency = 1f; // Adjust this value to control the frequency of the movement

    private Rigidbody cupRigidbody;
    private Vector3 initialPosition;
    public bool isObjectStopped;

    private void Start()
    {
        isObjectStopped = false;
        cupRigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!isObjectStopped)
        {
            // Calculate the horizontal movement based on a sinusoidal pattern
            float horizontalMovement = Mathf.Sin(Time.time * frequency) * movementRange;

            // Calculate the target position based on the initial position and horizontal movement
            Vector3 targetPosition = initialPosition - new Vector3(0, 0f, horizontalMovement);

            // Calculate the movement vector towards the target position
            Vector3 movement = (targetPosition - transform.position).normalized * (moveSpeed * Time.deltaTime);

            // Apply the movement to the cup
            cupRigidbody.velocity = movement;
        }
    }
}
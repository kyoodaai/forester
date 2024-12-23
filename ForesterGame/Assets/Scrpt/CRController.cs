using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 5.0f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float movementX = horizontalInput * movementSpeed * Time.deltaTime;
        float movementZ = verticalInput * movementSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(movementX, 0, movementZ);

        characterController.Move(movement);

        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
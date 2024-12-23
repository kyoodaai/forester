using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;       // ���������������� ����
    public Transform playerBody;                // ������ �� ������ ������
    public float verticalClampAngle = 85f;      // ������������ ���� ������� �� ��� X
    public float horizontalClampAngle = 45f;    // ������������ ���� �������� �� ��� Y

    private float xRotation = 0f;               // �������� �� ��� X (������)
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �������� ����������� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ������������ �������� �� ��� X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalClampAngle, verticalClampAngle); // ������������ ������

        // ������������ �������� �� ��� Y
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -horizontalClampAngle, horizontalClampAngle); // ������������ �������

        // ��������� �������� � ������
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f); // ��������� �������� ������ �� ��� Y
    }
}

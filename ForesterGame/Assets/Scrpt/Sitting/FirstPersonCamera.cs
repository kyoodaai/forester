using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;       // Чувствительность мыши
    public Transform playerBody;                // Ссылка на объект игрока
    public float verticalClampAngle = 85f;      // Максимальный угол наклона по оси X
    public float horizontalClampAngle = 45f;    // Максимальный угол поворота по оси Y

    private float xRotation = 0f;               // Вращение по оси X (наклон)
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем перемещение мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ограничиваем вращение по оси X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalClampAngle, verticalClampAngle); // Ограничиваем наклон

        // Ограничиваем вращение по оси Y
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -horizontalClampAngle, horizontalClampAngle); // Ограничиваем поворот

        // Применяем вращение к камере
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f); // Обновляем вращение игрока по оси Y
    }
}

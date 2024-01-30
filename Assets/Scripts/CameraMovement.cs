using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float XMinRotation;
    [SerializeField] private float XMaxRotation;
    [Range(1.0f, 10.0f)]
    [SerializeField] private float Xsensitivity;
    [Range(1.0f, 10.0f)]
    [SerializeField] private float Ysensitivity;
    private float rotAroundX, rotAroundY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
    }

    private void Update()
    {
        rotAroundX += Input.GetAxisRaw("Mouse Y") * Xsensitivity;
        rotAroundY += Input.GetAxisRaw("Mouse X") * Ysensitivity;

        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);

        CameraRotation();
    }

    private void CameraRotation()
    {
        transform.parent.rotation = Quaternion.Euler(0, rotAroundY, 0); // rotation of parent (player body)
        transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0); // rotation of Camera
    }
}

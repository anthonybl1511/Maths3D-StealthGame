using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float XMinRotation;
    public float XMaxRotation;
    [Range(1.0f, 10.0f)]
    public float Xsensitivity;
    [Range(1.0f, 10.0f)]
    public float Ysensitivity;
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

using UnityEngine;
using UnityEngine.InputSystem; // 1. Added the new Input System namespace

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Safety check to ensure a mouse is connected
        if (Mouse.current == null) return;

        // 2. Read mouse delta directly from the new Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        // Control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        // Clamp the rotation so we can't over-rotate
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Control rotation around y axis (Look left and right)
        yRotation += mouseX;

        // Applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;
    public float sensitivity = 20f;
    private float _xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        var mouseX = input.x;
        var mouseY = input.y;
        // Calculate camera rotation for looking up and down
        _xRotation -= mouseY * Time.deltaTime * sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
        // Apply this to our camera transform
        camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        // Rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivity);
    }
}
using UnityEngine;
using Data;

public class MouseMovement : MonoBehaviour
{
    public float Sensivity = 200f;
 
    private float _xRotation = 0f;
    private float _yRotation = 0f;
 
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    private void Update()
    {
        float mouseX = Input.GetAxis(Mouse.MouseX) * Sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis(Mouse.MouseY) * Sensivity * Time.deltaTime;
 
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _yRotation += mouseX;
 
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}
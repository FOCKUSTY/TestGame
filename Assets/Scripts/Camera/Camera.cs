using static Data.Mouse;
using UnityEngine;
using System;

public class Camera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform Player;

    public float SpeedScroll = 1f;
    public float SpeedX = 180f;
    public float SpeedY = 180f;
    public float Distance = 5f;

    private float _yMin = -20f;
    private float _yMax = 80f;
    private float x = 0f;
    private float y = 0f;

    private void Start()
    {
        Vector3 vector = transform.eulerAngles;

        x = vector.y;
        y = vector.x;
    }

    private void FixedUpdate()
    {
        if(Player)
        {
            Distance -= Input.GetAxis(MouseScrollWheel) * SpeedScroll;
            x += Input.GetAxis(MouseX) * SpeedX * Time.deltaTime;
            y += Input.GetAxis(MouseY) * SpeedY * Time.deltaTime;
            y = Math.Clamp(y, _yMin, _yMax);

            Quaternion rotation = Quaternion.Euler(y, x , 0);

            Vector3 position = rotation * new Vector3(0f, 0f, -Distance) + Player.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
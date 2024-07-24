using UnityEngine;
using Data;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;
    [SerializeField] private Transform FloorCheck;
    [SerializeField] private LayerMask FloorMask;
 
    public float Speed = 12f;
    public float Gravity = -9.81f * 2;
    public float JumpForce = 3f;
    public float FloorDistance = 0.4f;
 
    private Vector3 _velocity;
    private bool _grounded;

    private void Update()
    {
        _grounded = Physics.CheckSphere(FloorCheck.position, FloorDistance, FloorMask);

        float x = Input.GetAxis(Directions.Horizontal);
        float z = Input.GetAxis(Directions.Vertical);
 
        Vector3 move = transform.right * x + transform.forward * z;
 
        Debug.Log(_grounded);

        Controller.Move(move * Speed * Time.deltaTime);
 
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            _velocity.y = Mathf.Sqrt(JumpForce * -2f * Gravity);
 
        _velocity.y += Gravity * Time.deltaTime;
 
        Controller.Move(_velocity * Time.deltaTime);
    }
}
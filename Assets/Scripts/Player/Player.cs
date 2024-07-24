using static Data.Directions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float JumpForce = 6f;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private GameObject Floor;
    [SerializeField] private Transform Camera;

    private float _movementX;
    private float _movementY;
    private bool _grounded;
    private Vector3 _tempScale;
    private Rigidbody _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementHandler();
        // DirectionHandler();
        JumpHandler();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(nameof(Floor)))
            _grounded = true;
    }

    private void MovementHandler()
    {
        _movementX = Input.GetAxisRaw(Horisontal);
        _movementY = Input.GetAxisRaw(Vertical);

        transform.position += new Vector3(_movementX, 0f, _movementY) * Speed * Time.deltaTime;
    }

    private void DirectionHandler()
    {
        if(_movementX != 0)
            _tempScale.x = Mathf.Abs(transform.localScale.x) * _movementX;

        if(_movementY != 0)
            _tempScale.y = Mathf.Abs(transform.localScale.y) * _movementY;
    }

    private void JumpHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _grounded = false;
            _body.AddForce(new Vector3(0f, JumpForce), ForceMode.Impulse);
        }
    }
}

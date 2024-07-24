using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Player.transform.position;
    }

    void LateUpdate () 
    {        
        transform.position = Player.transform.position + _offset;
    }
}

/*     [SerializeField] private GameObject Player;
    public Vector3 _offset = new Vector3(0, 2, -10);
    private float _smoothTime = 0.25f;
    private Vector3 _currentVelocity;

    private void FixedUpdate() 
    {
        var position = Vector3.SmoothDamp(transform.position, Player.transform.position + _offset, ref _currentVelocity, _smoothTime);
        transform.position = position;
    } */
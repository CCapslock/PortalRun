using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float CameraSpeed;
    private Vector3 _startCameraPosition;
    private Vector3 _movingVector;
    private Vector3 _movingVectorBack;
    private void Awake()
    {
        _startCameraPosition = transform.position;
        _movingVector = new Vector3();
        _movingVectorBack = new Vector3();
    }
    private void FixedUpdate()
    {
        //transform.position = Player.position;
        if(transform.position.x < Player.position.x)
        {
            _movingVector.x = transform.position.x + CameraSpeed + 0.05f;
            transform.position = _movingVector;
        }
        if(transform.position.x > Player.position.x)
        {
            _movingVector.x = transform.position.x - CameraSpeed;
            transform.position = _movingVector;
        }
        if(transform.position.y < Player.position.y)
        {
            _movingVector.y = transform.position.y + CameraSpeed;
            transform.position = _movingVector;
        }
        if(transform.position.y > Player.position.y)
        {
            _movingVector.y = transform.position.y - CameraSpeed;
            transform.position = _movingVector;
        }
    }
}

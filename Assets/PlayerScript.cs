using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MovingSpeed;
    private Vector3 _movingVector;
    public bool CanTeleport;

    private void FixedUpdate()
    {
        _movingVector = transform.position;
        _movingVector.x -= MovingSpeed;
        transform.position = _movingVector;
    }
}

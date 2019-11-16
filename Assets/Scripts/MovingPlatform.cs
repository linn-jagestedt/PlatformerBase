using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [Range(0, 10)]
    public float PlatformSpeed;
    public Transform StartTransform;
    public Transform EndTransform;

    Rigidbody2D _platformRigidBody;
    Vector2 _direction;
    Transform _destination;

    void Start()
    {
        _platformRigidBody = this.GetComponent<Rigidbody2D>();
        SetDestination(StartTransform);
    }

    void FixedUpdate()
    {        
        _platformRigidBody.MovePosition((Vector2)this.transform.position + _direction * PlatformSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(this.transform.position, _destination.position) < PlatformSpeed * Time.fixedDeltaTime)
        {
            if (_destination == StartTransform)
            { SetDestination(EndTransform); }
            else
            { SetDestination(StartTransform); }
        }
    }

    void SetDestination(Transform dest)
    {
        _destination = dest;
        _direction = (_destination.position - this.transform.position).normalized;
    }

    public Vector2 GetMovement()
    {
        return new Vector2(_direction.x * PlatformSpeed, 0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0,10)]
    public float MovementSpeed;
    [Range(10, 50)]
    public float JumpForce;

    public bool UseRigidBody;

    private bool _grounded;

    private void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.ToLower() == "ground")
        { _grounded = true; }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.ToLower() == "ground")
        { _grounded = false; }
    }

    void FixedUpdate()
    {
        Vector2 temp = new Vector2();

        if(Input.GetKey(KeyCode.A))
        { temp.x = -MovementSpeed; }
        if (Input.GetKey(KeyCode.D))
        { temp.x = MovementSpeed; }
        if(_grounded && Input.GetKey(KeyCode.Space))
        { temp.y = JumpForce; }

        if (UseRigidBody)
        { GetComponent<Rigidbody2D>().AddForce(temp * 4); }
        else
        { GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x, GetComponent<Rigidbody2D>().velocity.y + temp.y / 12); }
    }
}

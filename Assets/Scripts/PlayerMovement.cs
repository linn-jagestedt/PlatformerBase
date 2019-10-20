using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5, 50)]
    public float MovementSpeed;
    [Range(100, 500)]
    public float JumpForce;

    public bool SmoothMotion;
    public bool DirectionalFlip;

    private bool _grounded;

    private void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        { _grounded = true; }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        { _grounded = false; }
    }

    void FixedUpdate()
    {
        Vector2 _vInput = new Vector2();

        if(Input.GetKey(KeyCode.A))
        { _vInput.x = -MovementSpeed; }

        if (Input.GetKey(KeyCode.D))
        { _vInput.x = MovementSpeed; }

        if(_grounded && Input.GetKey(KeyCode.Space))
        { _vInput.y = JumpForce; }

        Rigidbody2D _rigid = GetComponent<Rigidbody2D>();

        if (SmoothMotion && _grounded) 
        { _rigid.AddForce(_vInput); } 
        else 
        { _rigid.velocity = new Vector2(_vInput.x / 4, _rigid.velocity.y + _vInput.y / 50); } //divides by 6 as compensation for the lower force required compared to using Addforce.

        GetComponent<Animator>().SetFloat("Running", System.Math.Abs(_vInput.x));
        GetComponent<Animator>().SetFloat("Jumping", _rigid.velocity.y);
        GetComponent<Animator>().SetBool("Grounded", _grounded);

        if (DirectionalFlip && _vInput.x < 0) { GetComponent<SpriteRenderer>().flipX = true; }
        else if (DirectionalFlip && _vInput.x > 0) { GetComponent<SpriteRenderer>().flipX = false; }
    }

    public void Flip()
    {

    }
}

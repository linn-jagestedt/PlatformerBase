using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5, 50)]
    public float MovementSpeed;
    [Range(100, 300)]
    public float JumpForce;

    public bool SmoothMotion;
    public bool DirectionalFlip;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private bool _grounded;
    private bool _isflipped;
    private Rigidbody2D _rigid;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _grounded = IsGrounded();
        Vector2 _vInput = GetInput();

        if (SmoothMotion) 
        {
            //Uses physics to push the player
            _rigid.AddForce(_vInput); 
        } 
        else 
        {
            //less force is required to move the player the to push the player, hence /4 and /50.
            _rigid.velocity = new Vector2(_vInput.x / 4, _rigid.velocity.y + _vInput.y / 50); 
        } 

        //Calls the apropriate animation for the movement
        GetComponent<Animator>().SetFloat("Running", System.Math.Abs(_vInput.x));
        GetComponent<Animator>().SetFloat("Jumping", _rigid.velocity.y);
        GetComponent<Animator>().SetBool("Grounded", _grounded);

        //Flips the sprite depending on which way it is running
        if (DirectionalFlip && _vInput.x < 0) { GetComponent<SpriteRenderer>().flipX = true; }
        else if (DirectionalFlip && _vInput.x > 0) { GetComponent<SpriteRenderer>().flipX = false; }

        _rigid.velocity += GetPlatformMovement();
    }

    /* Check if the ground overlaps with any gameobjects on the "Ground" Layer,
     * if so the collider will be stored in collider, otherwise the collider
     * will be empty */

    private bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, GroundLayer);
        if (collider == null) { return false; }
        else { return true; }
    }

    /* Check if the ground overlaps with any gameobjects on the "Ground" Layer,
     * if so the if the collider is a MovingPlatform return its velocity */

    private Vector2 GetPlatformMovement()
    {
        Collider2D collider = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, GroundLayer);

        if (collider != null && collider.GetComponent<MovingPlatform>() != null)
        {
            // Get the platform's controller
            MovingPlatform platform = collider.gameObject.GetComponent<MovingPlatform>();
            // Get the platform's movement from the controller
            return platform.GetMovement();
        }
        return Vector2.zero;
    }

    private Vector2 GetInput()
    {
        Vector2 _vInput = new Vector2();

        if (Input.GetKey(KeyCode.A))
        { _vInput.x = -MovementSpeed; }

        if (Input.GetKey(KeyCode.D))
        { _vInput.x = MovementSpeed; }

        if (_grounded && Input.GetKey(KeyCode.W))
        { _vInput.y = JumpForce; }

        return _vInput;
    }
}

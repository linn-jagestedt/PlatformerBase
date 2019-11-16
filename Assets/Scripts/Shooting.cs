using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed = 8;
    public int Shotspeed = 16;
    private int _counter = 0;
    private bool _facingLeft;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.x < 0) { _facingLeft = true; }
        else if (GetComponent<Rigidbody2D>().velocity.x > 0) { _facingLeft = false; }

        if (_counter > Shotspeed && Input.GetKey(KeyCode.Space))
        {
            if (_facingLeft)
            { Instantiate(BulletPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, 0), Quaternion.identity).GetComponent<Bullet>().SetVelocity(new Vector2(-Speed, 0)); }
            else
            { Instantiate(BulletPrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, 0), Quaternion.identity).GetComponent<Bullet>().SetVelocity(new Vector2(Speed, 0)); }
            _counter = 0;
        }
        else { _counter++; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool _playerContact;
    private GameObject _player;
    public float KnockBack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            _playerContact = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        { _playerContact = false; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerContact && !_player.GetComponent<PlayerHealth>().Invincible)
        {
            Vector2 v;
            if (_player.transform.position.x < transform.position.x) { v = new Vector2(-KnockBack, 0); }
            else { v = new Vector2(KnockBack, 0); }
            _player.GetComponent<Rigidbody2D>().AddForce(v);
            _player.GetComponent<PlayerHealth>().Health--;
        }
    }
}
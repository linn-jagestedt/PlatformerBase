using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _playerContact;
    private GameObject _player;
    public float KnockBack;
    public int Damage;
    public int Health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerAttack")
        {
            Health--;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0) { Destroy(gameObject); }
    }

    public void Attack(GameObject gameObject)
    {
        Vector2 v;
        if (gameObject.transform.position.x < transform.position.x) { v = new Vector2(-KnockBack, 0); }
        else { v = new Vector2(KnockBack, 0); }
        gameObject.GetComponent<Rigidbody2D>().AddForce(v);
        gameObject.GetComponent<PlayerHealth>().Health -= Damage;
    }
}
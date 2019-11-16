using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public string GameOverScreen;
    public Transform Respawn;
    public int MaxHealth;

    [HideInInspector]
    public bool Invincible;
    private int _invicibilityCounter;
    private int _health;

    public int Health
    {
        get { return _health; }
        set
        {
            if (!Invincible)
            {
                //if the new health (value) is least than the current health the player has been damaged
                if (value < _health) 
                { Invincible = true; }

                if (value > MaxHealth)
                { _health = MaxHealth; }

                else if (value < 0) 
                { _health = 0; }

                else 
                { _health = value; }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = MaxHealth;
        _invicibilityCounter = 50;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<Enemy>().Attack(gameObject);
        }
    }

    void Update()
    {
        if(Invincible)
        {
            _invicibilityCounter--;

            //Creates the Flickering effect
            if(_invicibilityCounter % 4 == 0)
            { GetComponent<SpriteRenderer>().enabled = false; }
            else 
            { GetComponent<SpriteRenderer>().enabled = true; }

            //When the counter reaches 0, plyyer is no longer invincible
            if (_invicibilityCounter < 0)
            {
                Invincible = false;
                _invicibilityCounter = 50;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if(_health == 0)
        {
            SceneManager.LoadScene(GameOverScreen, LoadSceneMode.Single);     
        }
    }

    public void Reset()
    {
        _health = MaxHealth;
        transform.position = Respawn.position;
        gameObject.SetActive(true);
    }
}

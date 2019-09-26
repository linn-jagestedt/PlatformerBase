using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public bool Invincible;
    private int _health;
    private int _invcibilityCounter;

    public string GameOverScreen;
    public Transform Respawn;
    public int StartHealth;
    public int MaxHealth;

    public int Health
    {
        get { return _health; }
        set
        {
            if (!Invincible)
            {
                if(value < _health) //if the new health (value) is least than the current health the player has been damaged
                {
                    Invincible = true;
                }

                if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else if (value < 0)
                {
                    _health = 0;
                }
                else {
                    _health = value;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = StartHealth;
        _invcibilityCounter = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Invincible)
        {
            _invcibilityCounter--;
            if(_invcibilityCounter < 0)
            {
                Invincible = false;
                _invcibilityCounter = 10;
            }
        }

        if(_health == 0)
        {
            SceneManager.LoadScene(GameOverScreen, LoadSceneMode.Single);     
        }
    }

    public void Reset()
    {
        _health = StartHealth;
        transform.position = Respawn.position;
        gameObject.SetActive(true);
    }
}

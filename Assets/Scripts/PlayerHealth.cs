using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Counter
{
    [HideInInspector]
    public bool Invincible;
    private int _value;
    private int _invcibilityCounter;
    public override int Value
    {
        get { return _value; }
        set
        {
            if (!Invincible)
            {
                if(value < _value) //if the new health (value) is least than the current health the player has been damaged
                {
                    Invincible = true;
                }

                if (value > MaxHealth)
                {
                    _value = MaxHealth;
                }
                else if (value < 0)
                {
                    _value = 0;
                }
                else {
                    _value = value;
                }
            }
        }
    }

    public string GameOverScreen;
    public Transform Respawn;
    public int StartHealth;
    public int MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        _value = StartHealth;
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

        if(_value == 0)
        {
            SceneManager.LoadScene(GameOverScreen, LoadSceneMode.Single);     
        }
    }

    public void Reset()
    {
        _value = StartHealth;
        transform.position = Respawn.position;
        gameObject.SetActive(true);
    }
}

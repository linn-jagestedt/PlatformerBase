using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health;

    public Transform Respawn;
    public int MaxHealth;
    public int StartHealth;

    public int Health
    {
        get { return _health; }
        set
        {
            if (value > MaxHealth)
            { _health = MaxHealth; }
            else if (value < 0)
            { _health = 0; }
            else { _health = value; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = StartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_health == 0)
        {
            Debug.Log("GameOver");
            _health = StartHealth;
            transform.position = Respawn.position;
        }
    }
}

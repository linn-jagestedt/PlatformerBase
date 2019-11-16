using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    public Sprite[] Sprites;
    public PlayerHealth PlayerHealth;
    private Image _img;

    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<Image>();
    }

    public void Update()
    {
        int _index = PlayerHealth.Health;

        if(_index > Sprites.Length) 
        { _index = Sprites.Length; }
        if(_index < 0) 
        { _index = 0; }

        _img.sprite = Sprites[PlayerHealth.Health];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    public Sprite[] Sprites;
    public Counter Health;
    private Image _img;

    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<Image>();
    }

    public void Update()
    {
        int _index = Health.Value;

        if(_index > Sprites.Length) 
        { _index = Sprites.Length; }
        if(_index < 0) 
        { _index = 0; }

        _img.sprite = Sprites[Health.Value];
    }
}

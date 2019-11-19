using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coinAmount;

    [HideInInspector]
    public int CoinAmount
    {
        get { return _coinAmount; }
        set { _coinAmount = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _coinAmount = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Coin")
        { _coinAmount++; Destroy(collider.gameObject); }
    }
}

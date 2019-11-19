using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public CoinCollector CoinCollector;
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinCollector != null) { _text.text = CoinCollector.CoinAmount.ToString() + "G"; }
    }
}

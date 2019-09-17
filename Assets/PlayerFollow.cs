using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Follow;
    public float yOffset = 0;

    private Transform _follow;

    // Start is called before the first frame update
    void Start()
    {
        _follow = Follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_follow.position.x, _follow.position.y + yOffset, transform.position.z);
    }
}

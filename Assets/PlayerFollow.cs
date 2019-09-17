using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Follow;
    public Vector2 Wiggle;

    private Transform _follow;
    private float x_diff;
    private float y_diff;
    private float x_offset;
    private float y_offset;

    // Start is called before the first frame update
    void Start()
    {
        _follow = Follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        x_diff = transform.position.x - _follow.position.x;
        y_diff = transform.position.y - _follow.position.y;

        x_offset = 0;
        y_offset = 0;

        if (x_diff >= Wiggle.x)
        { x_offset = Wiggle.x; }
        if (x_diff <= -Wiggle.x)
        { x_offset = -Wiggle.x; }
        if (y_diff >= Wiggle.y)
        { y_offset = Wiggle.y; }
        if (y_diff <= -Wiggle.y)
        { y_offset = -Wiggle.y; }

        if (x_diff >= Wiggle.x || x_diff <= -Wiggle.x)
        { transform.position = new Vector3(_follow.position.x + x_offset, transform.position.y, transform.position.z); }
        if (y_diff >= Wiggle.y || y_diff <= -Wiggle.y)
        { transform.position = new Vector3(transform.position.x, _follow.position.y + y_offset, transform.position.z); }
    }
}

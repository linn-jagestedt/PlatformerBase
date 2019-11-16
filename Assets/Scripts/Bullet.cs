using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Lifespan = 25;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetVelocity(Vector2 velocity)
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter > Lifespan) 
        { Destroy(gameObject); }
        else { counter++; }
    }
}

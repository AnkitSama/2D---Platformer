using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocks : MonoBehaviour
{
    public float xMin,xMax;
    private Rigidbody2D rb;
    public float xDir;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xDir,0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x<=xMin || rb.position.x>=xMax)
        {
            rb.velocity *= -1;
        }
        //rb.velocity = new Vector2(xDir,0) * speed;
    }
}

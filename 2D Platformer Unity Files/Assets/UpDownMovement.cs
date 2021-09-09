using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float yMin,yMax;
    private Rigidbody2D rb;
    public float yDir;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,yDir) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y<=yMin || rb.position.y>=yMax)
        {
            rb.velocity *= -1;
        }
        //rb.velocity = new Vector2(xDir,0) * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{
    public float enemySpeed;
    public float yMoveDirection;

    public float xMoveDirection;

    public float distance;

    public float distanceBottom;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(xMoveDirection,0));
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        
        if (rayDown.collider != null && rayDown.distance < distanceBottom && rayDown.collider.tag == "Player")
        {
            Destroy(rayDown.collider.gameObject);
        }
        if(hit.distance<distance && hit.collider.tag=="Player")
        {
            Destroy(hit.collider.gameObject);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection,yMoveDirection) * enemySpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "ground")
        {
            yMoveDirection *= -1;
        }
        /*
        if(col.collider.tag == "Player")
        {
            Destroy(col.collider.gameObject);
        }*/
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ground")
        { 
            yMoveDirection *= -1;
        }
        if(col.gameObject.tag == "tree")
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale; 
            xMoveDirection *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed;
    public float xMoveDirection;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(xMoveDirection,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection,0) * enemySpeed;
        if(hit.distance<0.8f && hit.collider.tag=="Player")
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "tree")
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale; 
            xMoveDirection *= -1;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "tree")
        {
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale; 
            xMoveDirection *= -1;
        }
    }
}

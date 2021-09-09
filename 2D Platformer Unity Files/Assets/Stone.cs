using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag=="Player")
        {
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            Destroy(col.collider.gameObject);
            float t = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup - t <= 3) ;
            SceneManager.LoadScene("TuxLose");
        }
    }
}

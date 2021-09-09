using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controls : MonoBehaviour
{
    public float playerSpeed = 10f;
    //public bool facingRight = true;
    public float playerJumpPower = 1250f;
    public float time = 120;
    public float moveX;
    public bool isGrounded = true;
    public float distanceToBottomPlayer = 1.5f;
    public float distanceToGround;

    public float distanceToEnemy;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        /*
        if(GameObject.Find("nolok") == null && GetComponent<Rigidbody2D>().velocity.y==0)
        {
            Time.timeScale = 0;
        }
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x == 0 && gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            isGrounded = true;
        }*/

        RaycastHit2D down = Physics2D.Raycast(transform.position, Vector2.down);
        if (down.collider != null && down.distance < distanceToGround
            && (down.collider.tag == "ground" || down.collider.tag == "tree" || down.collider.tag == "coin_box")
            && down.collider.GetComponent<SpriteRenderer>() != null)
        {
            isGrounded = true;
        }


        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        if (isGrounded)
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }
        //animations
        if (moveX != 0) //there is an input so we are moving
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
        //playerDirection
        if (moveX < 0.0f)// && facingRight==true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)//&& facingRight==false)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Animator>().SetBool("isJumping", true);
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, playerJumpPower);
        isGrounded = false;
    }

    /* void FlipPlayer()
     {
         facingRight = !facingRight;
         Vector2 localScale = gameObject.transform.localScale;
         localScale.x *= -1;
         transform.localScale = localScale; 
     }*/

    /*
   void OnCollisionEnter2D(Collision2D col)
   {
       if (col.collider.tag == "ground")
       {
           isGrounded = true;
       }
   }*/

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "coin_?")
        {
            player_score.playerScore += 10;
            Destroy(trig.gameObject);
            GetComponents<AudioSource>()[0].Play();
        }
    }
    void PlayerRaycast()
    {


        //------->watch 2D PLATFORMER PATROL AI WITH UNITY AND C# - EASY TUTORIAL<----- to correct it


        /*RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        //if(rayUp != null && rayUp.collider != null && rayUp.distance<1.5f & rayUp.collider.tag=="enemy")
        if(rayUp != null && rayUp.collider != null && rayUp.distance<t && rayUp.collider.name=="coin_box")
        {
            Destroy(rayUp.collider.gameObject);
        }*/

        //ray down
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        //if(hit != null && hit.collider != null && hit.distance<1.5f & hit.collider.tag=="enemy")
        if (rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
            /*
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
            */
            if (rayDown.collider.name == "nolok")
            {
                //CamerSystem.Instance.CameraShake(5f, 0.1f);
                float t = Time.realtimeSinceStartup;
                while (Time.realtimeSinceStartup - t <= 1)
                {
                }
                int timeBounus;
                if (time - (int)time >= 0.5)
                {
                    timeBounus = (int)time + 1;
                }
                else
                {
                    timeBounus = (int)time;
                }
                player_score.playerScore += (int)timeBounus * 10;
                SceneManager.LoadScene("NolokDeath");
            }
            //rayDown.collider.gameObject.GetComponent<Animator>().SetBool("death", true);
            Destroy(rayDown.collider.gameObject);
            GetComponents<AudioSource>()[1].Play();
            player_score.playerScore += 20;
        }
        /*if(hit != null && hit.collider != null && hit.distance<1.5f & hit.collider.tag !="enemy")
        {
            isGrounded = true
        }*/
        float f = 0.1f;
        for (int i = 0; i < 9; i++)
        {

            RaycastHit2D rayRight = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - f, transform.position.z), new Vector2(1, 0));
            if (rayRight.collider != null && rayRight.distance < distanceToEnemy && rayRight.collider.tag == "enemy")
            {
                Destroy(gameObject);
                float t = Time.realtimeSinceStartup;
                while (Time.realtimeSinceStartup - t <= 1);
                SceneManager.LoadScene("TuxLose");
            }
            f += 0.1f;
        }

        f = 0.1f;
        for (int i = 0; i < 9; i++)
        {

            RaycastHit2D rayLeft = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - f, transform.position.z), new Vector2(-1, 0));
            if (rayLeft.collider != null && rayLeft.distance < distanceToEnemy && rayLeft.collider.tag == "enemy")
            {
                Destroy(gameObject);
                float t = Time.realtimeSinceStartup;
                while (Time.realtimeSinceStartup - t <= 1);
                SceneManager.LoadScene("TuxLose");
            }
            f += 0.1f;
        }

        f = 0.1f;
        for (int i = 0; i < 9; i++)
        {

            RaycastHit2D rayRight = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + f, transform.position.z), new Vector2(1, 0));
            if (rayRight.collider != null && rayRight.distance < distanceToEnemy && rayRight.collider.tag == "enemy")
            {
                Destroy(gameObject);
                float t = Time.realtimeSinceStartup;
                while (Time.realtimeSinceStartup - t <= 1);
                SceneManager.LoadScene("TuxLose");
            }
            f += 0.1f;
        }

        f = 0.1f;
        for (int i = 0; i < 9; i++)
        {

            RaycastHit2D rayLeft = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + f, transform.position.z), new Vector2(-1, 0));
            if (rayLeft.collider != null && rayLeft.distance < distanceToEnemy && rayLeft.collider.tag == "enemy")
            {
                Destroy(gameObject);
                float t = Time.realtimeSinceStartup;
                while (Time.realtimeSinceStartup - t <= 1);
                SceneManager.LoadScene("TuxLose");
            }
            f += 0.1f;
        }
    }
}

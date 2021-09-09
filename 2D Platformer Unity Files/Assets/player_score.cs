using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class player_score : MonoBehaviour
{
    public static float timeLeft = 240;
    public static float playerScore = 0;
    public TextMeshProUGUI timeLeftUI;
    public TextMeshProUGUI playerScoreUI;

    //testing
    /*
    void Start()
    {
        data_management.datamanagement.LoadData();
    }*/
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.GetComponent<TextMeshProUGUI>().text = ("Time Left : " + (int)timeLeft);
        playerScoreUI.GetComponent<TextMeshProUGUI>().text = ("Score : " + playerScore);
        if(timeLeft<0.1f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.name=="EndPole")
        {
            CountScore();
            //data_management.datamanagement.SaveData();
        }
        if(trig.gameObject.tag=="coin")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
            GetComponents<AudioSource>()[0].Play();
        }
    }

    public void CountScore()
    {
        //Debug.Log("Current : " + data_management.datamanagement.highScore);
        int timeBounus;
        if(timeLeft-(int)timeLeft >= 0.5)
        {
            timeBounus = (int)timeLeft + 1;
        }
        else
        {
            timeBounus = (int)timeLeft;
        }
        playerScore += (int)timeBounus*10;
        /*
        data_management.datamanagement.highScore = playerScore + (int)timeBounus*10;
        data_management.datamanagement.SaveData();
        Debug.Log("Now : " + data_management.datamanagement.highScore);
        */
    }
}

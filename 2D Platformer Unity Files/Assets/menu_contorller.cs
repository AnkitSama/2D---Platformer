using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_contorller : MonoBehaviour
{
    // Start is called before the first frame update
    public Button forestWorld;
    //public Button playVsplayer;
    //public Button rules;
    public Button quit;

    public Button goBack;
    public Button pause;


    public void ForestWorld()
    {
        SceneManager.LoadScene("ForestVertical");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Go_Back()
    {
        SceneManager.LoadScene("Menu");
        player_score.playerScore = 0;
        player_score.timeLeft = 240;
    }


    public void Rules()
    {
        SceneManager.LoadScene("The Story");
    }
    
    public void Pause_Game()
    {
            if(Time.timeScale==1f)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
    }
}

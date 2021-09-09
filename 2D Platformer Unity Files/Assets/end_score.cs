using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end_score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI playerScoreUI;
    void Start()
    {
        playerScoreUI.GetComponent<TextMeshProUGUI>().text = ("Score : " + player_score.playerScore);
    }
}

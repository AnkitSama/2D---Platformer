using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_spawn : MonoBehaviour
{
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("SelectedCharcter") == 0)
        {
            Instantiate(players[(0)], Vector2.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetInt("SelectedCharcter") == 1)
        {
            Instantiate(players[(1)], Vector2.zero, Quaternion.identity);
        }
    }
}

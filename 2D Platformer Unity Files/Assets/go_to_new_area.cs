using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_new_area : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trig)
    {
        SceneManager.LoadScene("ForestWorld");
    }
}

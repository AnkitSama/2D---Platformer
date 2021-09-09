using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character_selector : MonoBehaviour
{
    public void ChooseCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharcter", characterIndex);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

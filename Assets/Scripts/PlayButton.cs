using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void ShowIntro()
    {
        SceneManager.LoadScene("Intro_Video");
    }
}

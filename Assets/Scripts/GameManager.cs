using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        NumeroInimigosAnalise();
    }

    void NumeroInimigosAnalise() 
    {
        if (GameObject.FindWithTag("Inimigo") == null)
        {
            GameObject.FindWithTag("Portal").SetActive(true);
        }
        else
        {
            GameObject.FindWithTag("Portal").SetActive(false);
        }
    }
}

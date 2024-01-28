using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    
    public GameObject settings;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc key was pressed");
            settings.SetActive(!settings.activeSelf);
        }
    }
}

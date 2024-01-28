using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGenerator : MonoBehaviour
{
    public GameObject tiro;

    private Glow light;

    int numberPressed = 0;

    void Start()
    {
        light = gameObject.GetComponent<Glow>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Atirar();
            numberPressed += 1;
            if(numberPressed > 1)
            {
                light.increaseLight();
            }
        }
    }

    private void Atirar()
    {
        GameObject tiro1 = GameObject.Instantiate(tiro);
        tiro1.transform.position = transform.position;

    }

}

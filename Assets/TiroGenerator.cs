using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGenerator : MonoBehaviour
{
    public GameObject tiro;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        GameObject tiro1 = GameObject.Instantiate(tiro);
        tiro1.transform.position = transform.position;

    }

}

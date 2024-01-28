using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPickUp : MonoBehaviour
{
    public GameObject slowTimeGO;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(slowTimeGO);
            Destroy(gameObject);
        }
    }
}

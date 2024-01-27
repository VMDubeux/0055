using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject player;
    public GameObject portalTeleporte;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sexo");
            player.GetComponent<Transform>().position = portalTeleporte.GetComponent<Transform>().position;
        }
    }


    private void OnTr(Collider other)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject portalTeleporte;
    private GameObject player;
    public Vector3 acréscimo;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Transform>().position = portalTeleporte.transform.position + acréscimo;
    }
}

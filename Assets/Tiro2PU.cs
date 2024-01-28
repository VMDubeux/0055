using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro2PU : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().Tiro2();
        Destroy(gameObject,0.1f);
    }
}

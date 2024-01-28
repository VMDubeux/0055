using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Inimigo")
        {
            other.gameObject.GetComponent<InimigosSettup>().vidaEnemy--;
        }
        Destroy(gameObject,1);
    }
}

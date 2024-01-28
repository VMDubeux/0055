using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBullet : MonoBehaviour
{
    public GameObject thunderExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Inimigo")
        {
        Instantiate(thunderExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.01f);            
        }
    }        
}
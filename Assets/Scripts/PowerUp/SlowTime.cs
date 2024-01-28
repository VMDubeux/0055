using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    Light slowLight;
    Collider myCollider;
    bool light = false;
    private void Start()
    {
        slowLight = GetComponent<Light>();
        myCollider = GetComponent<Collider>();
        Slow();
    }
    void Slow()
    {
        slowLight.enabled = true;
        myCollider.enabled = true;
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Inimigo")
        {
            other.GetComponent<InimigosController>().EnemySpeed /= 2;
        }
    }
}

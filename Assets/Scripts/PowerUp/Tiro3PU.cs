using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro3PU : MonoBehaviour
{
    public GameObject confetes;
    Collider myCollider;
    private void Start()
    {
        myCollider = GetComponent<Collider>();
        Shoot();
    }
    public void Shoot ()
    {
        confetes.SetActive (true);
        myCollider.enabled = true;
        Destroy(gameObject, 1);
    }
}

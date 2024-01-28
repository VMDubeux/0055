using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroSettup : MonoBehaviour
{
    private Rigidbody rigidbodyBala;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            objetoDeColisao.gameObject.GetComponent<InimigosSettup>().vidaEnemy--;
        }

        Destroy(gameObject);
    }
}

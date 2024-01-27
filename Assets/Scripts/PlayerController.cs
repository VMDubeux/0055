using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    public GameObject portalTeleporte_1;
    public GameObject portalTeleporte_2;

    void Start()
    {

    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movements();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sexo");
        GetComponent<Transform>().position = portalTeleporte_2.transform.position;
    }

    void Movements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontal, 0, vertical);
        Vector3 movement = moveSpeed * Time.fixedDeltaTime * direction.normalized;
        transform.position += movement;
    }
}

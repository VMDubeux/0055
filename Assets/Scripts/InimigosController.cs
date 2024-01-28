using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosController : MonoBehaviour
{
    private GameObject playerObject;
    public float EnemySpeed = 0.1f;
    private Vector3 targetPosition;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        AIserra();
    }

    private void AIserra()
    {
        if (playerObject != null)
        {
            targetPosition = playerObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.LookRotation(playerObject.transform.position);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InimigosController : MonoBehaviour
{
    private GameObject playerObject;
    public float EnemySpeed = 0.1f;
    private Vector3 targetPosition;
    public Animator _enemyAnimator;
    private Rigidbody _enemyRigidbody;


    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        _enemyRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (playerObject != null)
        {
            float _distance = Vector3.Distance(transform.position, playerObject.transform.position);
            Vector3 _direction = playerObject.transform.position - transform.position;
            Quaternion _newRotation = Quaternion.LookRotation(_direction);
            _enemyRigidbody.MoveRotation(_newRotation);

            if (_distance > 0.5f)
            {
                targetPosition = playerObject.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.fixedDeltaTime);
                _enemyAnimator.SetBool("Atacando", false);
            }
            else
            {
                
                _enemyAnimator.SetBool("Atacando", true);
            }
        }
    }
}
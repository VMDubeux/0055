using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{

    [Header("Elements")]
    private CharacterController characterController;
    private PlayerAnimator playerAnimator;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10.0f;

    [Header("Others")]
    public GameObject muniçãoLuz;
    [SerializeField] private float balaVelocidade;
    public Transform canoArma;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        Tiro();
    }

    void FixedUpdate()
    {
        Movements();
    }

    void Movements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new(horizontal, 0, vertical);
        Vector3 movement = moveSpeed * Time.fixedDeltaTime * direction.normalized;
        
        characterController.Move(movement);
        playerAnimator.ManageAnimations(movement);
    }

    void Tiro()
    {
        float tiroDireçãoX = Input.GetAxis("Fire1");
        float tiroDireçãoY = Input.GetAxis("Fire2");

        if (Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 direction = new(tiroDireçãoX, 0, tiroDireçãoY);
            Vector3 movement = balaVelocidade * Time.deltaTime * direction.normalized;
            
            GameObject bala = Instantiate(muniçãoLuz, canoArma.transform.position, muniçãoLuz.transform.rotation);
            playerAnimator.ManageShootAnimation(movement);
            bala.GetComponent<Rigidbody>().velocity = movement; 
        }
        //playerAnimator.StopShootingAnimation();
    }
}


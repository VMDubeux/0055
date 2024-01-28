using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    public int vidaPlayer = 3;
    public float PlayerFireRateKeyX = 0.75f;
    private float _playerNextShoot = 0.0f;

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

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction != Vector3.zero)
        {
            // Calcula a rotação do personagem com base na direção do movimento
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

        Vector3 movement = moveSpeed * Time.fixedDeltaTime * direction;

        characterController.Move(movement);
        playerAnimator.ManageAnimations(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        vidaPlayer--;
    }

    void Tiro()
    {
        float tiroDireçãoX = Input.GetAxis("Fire1");
        float tiroDireçãoY = Input.GetAxis("Fire2");


        if ((Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow)) && (Time.time > _playerNextShoot))
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyX;
            
            //playerAnimator._animator.SetBool("isShooting", true);
            
            Vector3 direction = new(tiroDireçãoX, 0, tiroDireçãoY);
            Vector3 movement = balaVelocidade * Time.deltaTime * direction.normalized;
            GameObject bala = Instantiate(muniçãoLuz, canoArma.transform.position, muniçãoLuz.transform.rotation);
            bala.GetComponent<Rigidbody>().velocity = movement;
            Destroy(bala, 1.5f);

            //playerAnimator.ManageShootAnimation(movement);
            //playerAnimator._animator.SetLookAtPosition(direction);
            playerAnimator._animator.Play("Shoot");
        }
        //playerAnimator._animator.SetBool("isShooting", false);
        //playerAnimator.StopShootingAnimation();
    }
}
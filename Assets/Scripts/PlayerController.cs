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

        Vector3 direction = new(horizontal, 0, vertical);
        Vector3 movement = moveSpeed * Time.fixedDeltaTime * direction.normalized;

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

            Vector3 direction = new(tiroDireçãoX, 0, tiroDireçãoY);
            Vector3 movement = balaVelocidade * Time.deltaTime * direction.normalized;

            GameObject bala = Instantiate(muniçãoLuz, canoArma.transform.position, muniçãoLuz.transform.rotation);
            playerAnimator.ManageShootAnimation(movement);
            bala.GetComponent<Rigidbody>().velocity = movement;
            Destroy(bala, 1.5f);
        }
    }
    //playerAnimator.StopShootingAnimation();
}



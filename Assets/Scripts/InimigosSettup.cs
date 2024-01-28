using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosSettup : MonoBehaviour
{
    public GameManager gameManager;

    public PlayerController playerController;

    [SerializeField] public float vidaEnemy;
    public int essenciaLuz;
    //public GameObject sangueInimigo;

    //private AudioManager audioManager;

    [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    //public GameObject Explosion;
    public AudioClip AudioClipEnemiesMorte;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        DefeatMode();
    }

    private void DefeatMode()
    {
        if (vidaEnemy < 1.0f)
        {
            SummonPowerUp();
            Destroy(gameObject);
            //GameManager.Instance.RecordPlus(pointsForGive);
            //audioManager.PlaySFX("Explosion", 0.15f);
            FornecerEssenciaLuz();
            MorteEnemy();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        EnemyTakeDamage(other);
    }

    public void EnemyTakeDamage(Collider other)  //Inimigo tomando dano do player
    {
        if (other.CompareTag("Tiro"))
        {
            vidaEnemy--;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player")) 
        {
            other.GetComponent<PlayerController>().vidaPlayer--;
        }
    }

    public void PlayerGetPowerUp(Collision collision)      //Power up colide com o "Player"
    {
        if (collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Boss"))
        {
            //GameManager.instance.RecordPlus(pointsForGive);
            SummonPowerUp();
            Destroy(gameObject);
        }
    }

    public void SummonPowerUp()        // Invoca o power up baseado em %
    {
        int porcentagem = Random.Range(0, 101);
        if (porcentagem >= 80)
        {
            int powerUps = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[powerUps], transform.position, powerUp[powerUps].transform.rotation);
        }
    }

    public void FornecerEssenciaLuz()
    {
        gameManager.EssenciaBar.value += 0.5f;
    }

    public void MorteEnemy()
    {
        //GameObject sangue = Instantiate(sangueInimigo, transform.position, transform.rotation);
        //Destroy(sangue, 0.3f);
    }
}
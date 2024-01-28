using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Image[] cora��esCheios;
    public Image[] cora��esVazios;
    public static GameManager Instance;
    private int cora��esQuantidade = 3;
    PlayerController playerController;
    public Image canvasDerrota;
    public Slider EssenciaBar;


    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        EssenciaBar.maxValue = 100;
        EssenciaBar.minValue = 10;
        EssenciaBar.value = 0;
    }

    void Update()
    {
        NumeroInimigosAnalise();
        AtualizarVida();
        AtualizarEssencia();
    }

    void NumeroInimigosAnalise()
    {
        if (GameObject.FindWithTag("Inimigo") == null)
        {
            GameObject.FindWithTag("Portal").SetActive(true);
        }
        else
        {
            GameObject.FindWithTag("Portal").SetActive(false);
        }
    }

    public float AtualizarEssencia() 
    {
        return EssenciaBar.value;
    }

    public void AtualizarVida()
    {
        Debug.Log(cora��esQuantidade);
        cora��esQuantidade = playerController.vidaPlayer;
        switch (cora��esQuantidade)
        {
            case 1:
                cora��esCheios[0].gameObject.SetActive(true);
                cora��esCheios[1].gameObject.SetActive(false);
                cora��esCheios[2].gameObject.SetActive(false);
                break;

            case 2:
                cora��esCheios[0].gameObject.SetActive(true);
                cora��esCheios[1].gameObject.SetActive(true);
                cora��esCheios[2].gameObject.SetActive(false);
                break;

            case 3:
                cora��esCheios[0].gameObject.SetActive(true);
                cora��esCheios[1].gameObject.SetActive(true);
                cora��esCheios[2].gameObject.SetActive(true);
                break;

            default:
                cora��esCheios[0].gameObject.SetActive(false);
                cora��esCheios[1].gameObject.SetActive(false);
                cora��esCheios[2].gameObject.SetActive(false);
                canvasDerrota.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}

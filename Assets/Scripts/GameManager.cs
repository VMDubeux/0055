using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] coraçõesCheios;
    public Image[] coraçõesVazios;
    public static GameManager Instance;
    private int coraçõesQuantidade = 3;
    PlayerController playerController;
    public Image canvasDerrota;

    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        NumeroInimigosAnalise();
        AtualizarVida();
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

    public void AtualizarVida()
    {
        Debug.Log(coraçõesQuantidade);
        coraçõesQuantidade = playerController.vidaPlayer;
        switch (coraçõesQuantidade)
        {
            case 1:
                coraçõesCheios[0].gameObject.SetActive(true);
                coraçõesCheios[1].gameObject.SetActive(false);
                coraçõesCheios[2].gameObject.SetActive(false);
                break;

            case 2:
                coraçõesCheios[0].gameObject.SetActive(true);
                coraçõesCheios[1].gameObject.SetActive(true);
                coraçõesCheios[2].gameObject.SetActive(false);
                break;

            case 3:
                coraçõesCheios[0].gameObject.SetActive(true);
                coraçõesCheios[1].gameObject.SetActive(true);
                coraçõesCheios[2].gameObject.SetActive(true);
                break;

            default:
                coraçõesCheios[0].gameObject.SetActive(false);
                coraçõesCheios[1].gameObject.SetActive(false);
                coraçõesCheios[2].gameObject.SetActive(false);
                canvasDerrota.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}

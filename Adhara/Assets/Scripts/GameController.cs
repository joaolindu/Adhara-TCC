using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //public Text textoVidas;
    public static GameController instance;

    public GameObject pause;
    public GameObject gameOver;
    private bool isPaused;
    

    //public int quantidade;
    //public Text textoColetaveis;
    
    // Awak eh chamado antes de todos os metodos start()
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PauseJogo();
    }

    /*public void atualizarColetaveis(int valorColetaveis)
    {
        quantidade += valorColetaveis;
        textoColetaveis.text = quantidade.ToString();
    }*/

    public void PauseJogo()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pause.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}

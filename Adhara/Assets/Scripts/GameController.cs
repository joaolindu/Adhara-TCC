using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text textoVidas;
    public static GameController instance;
    
    // Awak eh chamado antes de todos os metodos start()
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizarVidas(int valor)
    {
        textoVidas.text = "x " + valor.ToString();
    }
}

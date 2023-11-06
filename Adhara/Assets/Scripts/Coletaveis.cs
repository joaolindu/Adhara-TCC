using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletaveis : MonoBehaviour
{
    private int valorDePontuacao;
    public Text textoDosColetaveis;

    private void Start()
    {
        valorDePontuacao = 0;
    }

    private void Update()
    {
        textoDosColetaveis.text = valorDePontuacao.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coletavel") == true)
        {
            valorDePontuacao = valorDePontuacao + 1;
            Destroy(col.gameObject);
        }
    }


    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameController.instance.atualizarColetaveis(valorDePontuacao);
            Destroy(gameObject);
        }  }*/
}


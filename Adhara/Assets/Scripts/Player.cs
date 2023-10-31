using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
 
    public Slider barraDeVidaDoJogador;
    
    public int vidaMaxima;
    public int vidaAtual;

    
    void Start()
    {
        //energiaAtual = energiaMaxima;
        vidaAtual = vidaMaxima;
        barraDeVidaDoJogador.maxValue = vidaMaxima;
        barraDeVidaDoJogador.value = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceberDano()
    {
        //energiaAtual -= dano;
        vidaAtual -= 1;
        barraDeVidaDoJogador.value = vidaAtual;
        if (vidaAtual <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}



/*public void ganharEnergia(int quantidadeDeEnergia)
    {
        energiaAtual += quantidadeDeEnergia;
        if (energiaAtual > quantidadeDeEnergia)
        {
            energiaAtual = energiaMaxima;
        }
    }*/
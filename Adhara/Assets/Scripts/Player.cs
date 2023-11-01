using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public int Vidas;
    public int vidaMaxima;

    private Animator anim;
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
        //energiaAtual = energiaMaxima;
        //vidaAtual = vidaMaxima;
        //barraDeVidaDoJogador.maxValue = vidaMaxima;
        //barraDeVidaDoJogador.value = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceberDano(int dano)
    {
        Vidas -= dano;
        barraDeVidaDoJogador.value = Vidas;
        anim.SetTrigger("hit");
        if (transform.rotation.y == 0)
        {
           
        }
        if (transform.rotation.y == 180)
        {
            
        }
        if (Vidas <= 0)
        {
            Debug.Log("Game Over");
        }
        //energiaAtual -= dano;
        /*vidaAtual -= 1;
        barraDeVidaDoJogador.value = vidaAtual;
        if (vidaAtual <= 0)
        {
            Debug.Log("Game Over");
        }*/
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
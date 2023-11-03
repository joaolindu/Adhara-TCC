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
    public int vidasAtual;

    private Animator anim;
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
        
        vidasAtual = vidaMaxima;
        barraDeVidaDoJogador.maxValue = vidaMaxima;
        barraDeVidaDoJogador.value = vidaMaxima;
        
        //energiaAtual = energiaMaxima;
    }
    
    void Update()
    {
        
    }

    /*public void ReceberDano(int danoParaReceber)
    {

        vidasAtual -= danoParaReceber;
        anim.SetTrigger("hit");
        barraDeVidaDoJogador.value = vidasAtual;
        if (transform.rotation.y == 0)
        {
            
        }
        if (transform.rotation.y == 180)
        {
            
        }
        if (vidasAtual <= 0)
        {
            Debug.Log("game over!");
        }


        /*Vidas -= dano;
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
        }
    }*/
}



/*public void ganharEnergia(int quantidadeDeEnergia)
    {
        energiaAtual += quantidadeDeEnergia;
        if (energiaAtual > quantidadeDeEnergia)
        {
            energiaAtual = energiaMaxima;
        }
    }*/
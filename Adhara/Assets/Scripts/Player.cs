using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //energia
    //public int energiaMaxima;
    //public int energiaAtual;
    
    
    public Slider barraDeVidaDoJogador;
    
    public int vidaMaxima;
    public int vidaAtual;

    /*public GameObject laser; //projetil
    public Transform arma; //posição q sera disparado o tiro
    private bool tiros;
    public float forcaDoTiro; //velocidade do tiro*/
    //private bool flipX = false;

    // Start is called before the first frame update
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
        //tiros = Input.GetButtonDown("Fire1");
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
    
    /*private void atirar()
    {
        
        if (tiros == true)
        {
            GameObject temp = Instantiate(laser);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 2f);
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
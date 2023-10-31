using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoPatrulheiro : MonoBehaviour
{
    
    public float velocidade;
    public float tempoDeAndar;
    private float tempo;
    public bool andarParaADirecao = true;

    public int vida;

    //private Animator anim;
    public Rigidbody2D rig;
    
    //public int vidaAtualDoInimigo;
    //public int vidaMaximaDoInimigo;
    
    
    void Start()
    {
        //vidaAtualDoInimigo = vidaMaximaDoInimigo;
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

   
    void FixedUpdate()
    {
        tempo += Time.deltaTime;
        if (tempo >= tempoDeAndar)
        {
            andarParaADirecao = !andarParaADirecao;
            tempo = 0f;
        }

        if (andarParaADirecao)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * velocidade;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * velocidade;
        }
        
    }

    public void Dano(int damage)
    {
        vida -= damage;
        //anim.SetTrigger("hit");

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;
        if(vidaAtualDoInimigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }*/
}

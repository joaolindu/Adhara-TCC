using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoVoador : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento do inimigo
    public float alturaMaxima = 4f; // Altura máxima que o inimigo pode alcançar
    public float alturaMinima = 1f; // Altura mínima que o inimigo pode alcançar
   
    public bool subindo = true; // Indica se o inimigo está subindo ou descendo
    public int vida;
    private int danoo;
    
    //public int vidaAtualDoInimigo;
    //public int vidaMaximaDoInimigo;

    private void Start()
    {
        
    }

    private void Update()
    {
        // Move o inimigo para cima ou para baixo
        if (subindo)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
        // Verifica se o inimigo atingiu a altura máxima ou mínima
        if (subindo && transform.position.y >= alturaMaxima)
        {
            subindo = false;
            //tempoPassado = 0f;
        }
        
        if (!subindo && transform.position.y <= alturaMinima)
        {
            subindo = true;
            //tempoPassado = 0f;
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Controles>().ReceberDano(danoo);
        }
    }
    
}


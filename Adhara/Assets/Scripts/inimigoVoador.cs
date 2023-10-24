using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoVoador : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento do inimigo
    public float alturaMaxima = 4f; // Altura máxima que o inimigo pode alcançar
    public float alturaMinima = 1f; // Altura mínima que o inimigo pode alcançar
    public float tempoDeEspera = 2f; // Tempo de espera em cada ponto máximo ou mínimo

    private bool subindo = true; // Indica se o inimigo está subindo ou descendo
    private float tempoPassado = 0f; // Contador de tempo
    
    public int vidaAtualDoInimigo;
    public int vidaMaximaDoInimigo;

    private void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
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

        // Atualiza o contador de tempo
        tempoPassado += Time.deltaTime;

        // Verifica se o inimigo atingiu a altura máxima ou mínima
        if (subindo && transform.position.y >= alturaMaxima)
        {
            subindo = false;
            tempoPassado = 0f;
        }
        else if (!subindo && transform.position.y <= alturaMinima)
        {
            subindo = true;
            tempoPassado = 0f;
        }

        // Aplica um tempo de espera
        if (tempoPassado >= tempoDeEspera)
        {
            tempoPassado = 0f;
            subindo = !subindo; // Inverte a direção após o tempo de espera
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;
        if(vidaAtualDoInimigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}


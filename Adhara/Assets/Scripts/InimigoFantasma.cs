using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFantasma : MonoBehaviour
{
    [Header("Verificação do andar")]
    private bool podeAndar;
    private VerificarDirecao oVerificarDirecao;
    
    [Header("Movimento do inimigo")]
    [SerializeField]private float velocidadeDoInimigo;
    [SerializeField]private bool indoParaDireita;
    private GameObject oJogador;
    
    private void Awake()
    {
        oJogador = GameObject.FindGameObjectWithTag("Player");
        oVerificarDirecao = oJogador.GetComponent<VerificarDirecao>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        podeAndar = true;
    }

    // Update is called once per frame
    private void Update()
    {
        verificarSePodeAndar();
        seguirJogador();
        espelharNaHorizontal();
    }
    private void verificarSePodeAndar()
    {
        if (indoParaDireita)
        {
            if (oVerificarDirecao.indoParaDireita)
            {
                podeAndar = true;
            }
            else
            {
                podeAndar = false;
            }
        }
        else
        {
            if (oVerificarDirecao.indoParaDireita)
            {
                podeAndar = false;
            }
            else
            {
                podeAndar = true;
            } 
        }
    }

    private void seguirJogador()
    {
        if (podeAndar)
        {
            transform.position = Vector2.MoveTowards(transform.position, oJogador.transform.position, velocidadeDoInimigo * Time.deltaTime);
        }
    }

    private void espelharNaHorizontal()
    {
        if (oJogador.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            indoParaDireita = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

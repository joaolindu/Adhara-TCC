using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletaveis2 : MonoBehaviour
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
        if (col.CompareTag("ColetavelGota") == true)
        {
            valorDePontuacao = valorDePontuacao + 1;
            EfeitosSonoros.instance.ColetavelGota.Play();
        }
        Destroy(col.gameObject);
    }
}

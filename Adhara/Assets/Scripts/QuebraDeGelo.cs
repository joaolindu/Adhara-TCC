using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuebraDeGelo : MonoBehaviour
{
    public float pesoMaximo = 2f; // Peso máximo que a plataforma de gelo pode suportar
    public GameObject efeitoQuebra; // Prefab do efeito visual de quebra

    private Rigidbody2D rb;
    private bool quebrado;
    private bool jogadorEmCima;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > pesoMaximo && !quebrado)
        {
            Quebrar();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorEmCima = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorEmCima = false;
        }
    }

    private void Update()
    {
        if (jogadorEmCima && !quebrado && rb.bodyType != RigidbodyType2D.Dynamic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.freezeRotation = false;
        }
    }

    private void Quebrar()
    {
        quebrado = true;
        Instantiate(efeitoQuebra, transform.position, Quaternion.identity); // Criar o efeito visual de quebra
        Destroy(gameObject); // Destruir a plataforma de gelo quebrada
    }
}

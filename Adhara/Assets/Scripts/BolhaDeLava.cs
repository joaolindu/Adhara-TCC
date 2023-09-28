using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaDeLava : MonoBehaviour
{

    public float bubbleSpeed = 2.0f; // Velocidade de subida das bolhas de lava

    private void Start()
    {
        // Inicializa o movimento da bolha de lava
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * bubbleSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se a bolha de lava colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Colisão com o jogador, destrói a bolha de lava
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaDeFogo : MonoBehaviour
{
    public int quantidadeDeDano = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null) // Verifica se o componente "Player" foi encontrado
            {
                player.ReceberDano(dano: 1);
                Destroy(gameObject);
                Debug.Log("ta funcionando");
            }
        }
    }

    public void SetDamage(int damage)
    {
        quantidadeDeDano = damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaDeFogo : MonoBehaviour
{
    public int quantidadeDeDano = 10;
    public int danoParaDar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Controles player = other.GetComponent<Controles>();
            if (player != null) // Verifica se o componente "Player" foi encontrado
            {
                player.ReceberDano(danoParaDar);
                Destroy(gameObject);
            }
        }
    }

    public void SetDamage(int damage)
    {
        quantidadeDeDano = damage;
    }
}

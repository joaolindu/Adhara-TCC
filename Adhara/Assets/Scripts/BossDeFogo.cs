using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeFogo : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public GameObject projectilePrefab; // Prefab do projétil
    public GameObject meteorPrefab; // Prefab do meteoro
    public float moveSpeed = 3f; // Velocidade de movimento do chefe
    public float projectileSpeed = 5f; // Velocidade dos projéteis
    public float meteorInterval = 5f; // Intervalo entre as quedas de meteoros
    private float nextMeteorTime; // Tempo para a próxima queda de meteoro

    void Update()
    {
        // Movimento em direção ao jogador
        Vector3 moveDirection = (player.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Atirar projéteis na direção do jogador
        ShootAtPlayer();

        // Verificar se é hora de soltar um meteoro
        if (Time.time > nextMeteorTime)
        {
            DropMeteor();
            nextMeteorTime = Time.time + meteorInterval;
        }
    }

    void ShootAtPlayer()
    {
        Vector3 playerDirection = (player.position - transform.position).normalized;

        // Cria um projétil teleguiado
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Define a direção e velocidade do projétil
        rb.velocity = playerDirection * projectileSpeed;
    }

    void DropMeteor()
    {
        // Cria um meteoro
        Vector3 meteorPosition = new Vector3(Random.Range(-5f, 5f), 7f, 0f); // Posição aleatória acima da tela
        Instantiate(meteorPrefab, meteorPosition, Quaternion.identity);
    }
}

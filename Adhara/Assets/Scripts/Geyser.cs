using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Geyser : MonoBehaviour
{
    public GameObject gotasDeFogo;
    public float tempoDeErupcao = 2f;
    public float forcaDasGotas = 10f;
    public float raio = 1f; 
    public int maximoDeGotasPorErupcao = 3;
    private void Start()
    {
        // Inicia o loop de erupções
        StartCoroutine(Erupt());
    }

    private IEnumerator Erupt()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempoDeErupcao);

            // Cria um número aleatório de gotas para esta erupção
            int dropsToSpawn = Random.Range(1, maximoDeGotasPorErupcao + 1);

            for (int i = 0; i < dropsToSpawn; i++)
            {
                // Cria uma posição aleatória dentro do raio da área de erupção
                Vector2 randomPosition = Random.insideUnitCircle * raio;
                Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

                // Instancia uma gota de fogo no local aleatório
                GameObject fireDrop = Instantiate(gotasDeFogo, spawnPosition, Quaternion.identity);

                // Aplica uma força para lançar a gota para cima
                Rigidbody2D rb = fireDrop.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(Vector2.up * forcaDasGotas, ForceMode2D.Impulse);
                }
            }
        }
    }
}

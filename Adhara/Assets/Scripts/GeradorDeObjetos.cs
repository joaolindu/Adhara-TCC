using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    public GameObject[] objetosParaGerar;
    public Transform[] pontosDeSpawn;

    public float tempoMaximoDosSpawns;
    public float tempoAtualDsSpawns;
    
    // Start is called before the first frame update
    void Start()
    {
        tempoAtualDsSpawns = tempoMaximoDosSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualDsSpawns -= Time.deltaTime;
        if (tempoAtualDsSpawns <= 0)
        {
            gerarObjetos();
        }
    }

    private void gerarObjetos()
    {
        int objetoAleatorio = Random.Range(0, objetosParaGerar.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);
        Instantiate(objetosParaGerar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, Quaternion.Euler(0f, 0f, 0f));
        tempoAtualDsSpawns = tempoMaximoDosSpawns;
    }
}

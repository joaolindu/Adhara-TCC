using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class tiroTeleguiadoDoInimigo : MonoBehaviour
{

    public GameObject laserDoInimigo;
    public float delay;

    public Transform localDeDisparo;
    public Transform _Player;

    private SpriteRenderer _renderer;

    public int danoParaDar;

    
    void Start()
    {
        _Player = GameObject.FindWithTag("Player").transform;
        StartCoroutine("Atirar");
        TryGetComponent(out _renderer);
    }

    
    void Update()
    {
        _renderer.flipX = _Player.position.x >= transform.position.x;
    }

    public void TiroTeleguiado()
    {
        localDeDisparo.right = _Player.transform.position - transform.position;
        GameObject temporaria = Instantiate(laserDoInimigo, localDeDisparo.position, quaternion.identity);
        localDeDisparo.LookAt(_Player);
        temporaria.GetComponent<Rigidbody2D>().velocity = localDeDisparo.forward * 3;
    }

    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(delay);
        TiroTeleguiado();
        StartCoroutine("Atirar");
    }
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Controles>().ReceberDano(danoParaDar);
            Destroy(this.gameObject);
        }
    }
}

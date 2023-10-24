using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroTeleguiadoDoInimigo : MonoBehaviour
{

    public GameObject laserDoInimigo;
    public float delay;

    public Transform localDeDisparo;
    public Transform _Player;
    
    public float velocidadeDoLaser;
    public int danoParaDar;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Atirar");
    }

    // Update is called once per frame
    void Update()
    {
        movimentarLaser();
    }

    public void TiroTeleguiado()
    {
        localDeDisparo.right = _Player.transform.position - transform.position;
        GameObject temporaria = Instantiate(laserDoInimigo, localDeDisparo.position, localDeDisparo.localRotation);
        temporaria.GetComponent<Rigidbody2D>().velocity = localDeDisparo.right * 3;
    }

    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(delay);
        TiroTeleguiado();
        StartCoroutine("Atirar");
    }
    private void movimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().ReceberDano();
            Destroy(this.gameObject);
        }
    }
}

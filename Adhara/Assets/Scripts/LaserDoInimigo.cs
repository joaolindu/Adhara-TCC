using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoInimigo : MonoBehaviour
{

    //public float velocidadeDoLaser;
    public int danoParaDar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentarLaser();
    }

    private void movimentarLaser()
    {
        //transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Controles>().ReceberDano(danoParaDar);
            EfeitosSonoros.instance.danoNaAdhara.Play();
            Destroy(this.gameObject);
        }
    }
}

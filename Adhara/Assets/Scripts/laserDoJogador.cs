using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDoJogador : MonoBehaviour
{
    //public float velocidadeDoLaser;
    public int danoParaDar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimentarLaser();
    }

    /*private void movimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }*/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<inimigoVoador>().MachucarInimigo(danoParaDar);
            col.gameObject.GetComponent<inimigoPatrulheiro>().MachucarInimigo(danoParaDar);
            Destroy(this.gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDoJogador : MonoBehaviour
{
    public float velocidadeDoLaser;
    public int danoParaDar;
    
    
    public bool isRight;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            rig.velocity = Vector2.right * velocidadeDoLaser; 
        }
        else
        {
            rig.velocity = Vector2.left * velocidadeDoLaser; 
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //col.GetComponent<inimigoVoador>().Dano(danoParaDar);
            col.GetComponent<inimigoPatrulheiro>().Dano(danoParaDar);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("InimigoVoador"))
        {
            col.GetComponent<inimigoVoador>().Dano(danoParaDar);
            Destroy(gameObject);
        }    
    }
    /*void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "Player")
       {
           
           Destroy(gameObject);
       }
    }*/
}

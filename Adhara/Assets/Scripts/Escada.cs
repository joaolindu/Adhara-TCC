using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : MonoBehaviour
{

    private float vertical;
    public float velocidadeDeSubir;
    private bool escada;
    private bool escalando;

    public Rigidbody2D rig;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (escada && Math.Abs(vertical) > 0f)
        {
            escalando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Escada"))
        {
            escada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Escada"))
        {
            escada = false;
            escalando = true;
        }
    }

    private void FixedUpdate()
    {
        if (escalando == true)
        {
            rig.gravityScale = 0f;
            rig.velocity = new Vector2(rig.velocity.x, vertical * velocidadeDeSubir);
        }
        else
        {
            rig.gravityScale = 3f;
        }
    }
}

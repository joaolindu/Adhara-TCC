using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Estalactites : MonoBehaviour
{
    private Rigidbody2D rig;
    public Collider2D collisor;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().ReceberDano();
            rig.bodyType = RigidbodyType2D.Dynamic;
            rig.gravityScale = Random.Range(2f, 8f);
            Destroy(this.gameObject, 1.5f);
        }
    }
}

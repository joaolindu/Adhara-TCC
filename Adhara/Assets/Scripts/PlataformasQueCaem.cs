using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasQueCaem : MonoBehaviour
{

    private Rigidbody2D rig;

    public float fallDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(2f);
        rig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, fallDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Fall");
        }
    }
}

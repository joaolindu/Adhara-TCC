using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoPatrulheiro : MonoBehaviour
{
    
    public float velocidade;
    public Rigidbody2D rig;
    private bool faceFlip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
    private void FlipEnemy()
    {
        if(faceFlip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("Player") && !col.collider.CompareTag("chao"))
        {
            faceFlip = !faceFlip;
        }
        FlipEnemy();
    }
}

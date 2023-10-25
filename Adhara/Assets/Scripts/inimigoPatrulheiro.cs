using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoPatrulheiro : MonoBehaviour
{
    
    public float velocidade;
    //public float distancia;
    //private bool estaCerto;
    //public Transform groundCheck;
    
    
    public Rigidbody2D rig;
    private bool faceFlip; //virada de rosto
    public int vidaAtualDoInimigo;
    public int vidaMaximaDoInimigo;
    
    
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

   
    void Update()
    {
       transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        /*RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distancia);

        if (ground.collider == false)
        {
            if (estaCerto == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                estaCerto = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }*/
        FlipEnemy();
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
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;
        if(vidaAtualDoInimigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

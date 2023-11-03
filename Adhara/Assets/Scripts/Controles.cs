using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Controles : MonoBehaviour
{ 
    public float velocidade;
    public float forcaDoPulo;
    private bool isJumping;
    
    //Attack
    public GameObject laserDoJogador; //projetil
    public Transform localDeDiparo; //posição q sera disparado o tiro
    private bool tiros;
    private bool isFire;
    private float movement;

    public Rigidbody2D rig;
    private Animator anim;
    private Vector3 respawnPoint;
    
    //vida
    public Slider barraDeVidaDoJogador;
   public int vidaMaxima;
    public int vidasAtual = 5;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        vidasAtual = vidaMaxima;
        barraDeVidaDoJogador.maxValue = vidaMaxima;
        barraDeVidaDoJogador.value = vidaMaxima;
        //GameController.instance.atualizarVidas(vidasAtual);

        transform.position = respawnPoint;
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Jump();
        Laser();
    }

    private void FixedUpdate()
    {
        movimentacao();
    }

    void movimentacao()
    {
        movement = Input.GetAxis("Horizontal"); //se pressionar botao para a direita, valor max e 1 se pressionar para a esquerda valor max e -1
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y); //adiciona velocidade ao personagem no eixo x e y
    
        
        if (movement > 0 && !isJumping) //se move para a direita
        {
            anim.SetInteger("Transition", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (movement < 0 && !isJumping && !isFire) //se move para a esquerda
        {
            anim.SetInteger("Transition", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (movement == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("Transition", 0);
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            // "!" significa false ex: !isJumpg
            if (!isJumping) 
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0,forcaDoPulo),ForceMode2D.Impulse); //adiciona forca
                isJumping = true;
            }
        }
    }
    void Laser()
    {
      StartCoroutine("tiro");
    }

    IEnumerator tiro()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isFire = true;
            anim.SetInteger("Transition", 3);
            GameObject laser = Instantiate(laserDoJogador, localDeDiparo.position, localDeDiparo.rotation);
            if (transform.rotation.y == 0)
            {
                laser.GetComponent<laserDoJogador>().isRight = true;
            }
            if (transform.rotation.y == 180)
            {
                laser.GetComponent<laserDoJogador>().isRight = false;
            }
            yield return new WaitForSeconds(0.5f);
            anim.SetInteger("Transition", 0);

        }
    }

    public void ReceberDano(int danoParaReceber)
    {
        vidasAtual -= danoParaReceber;
        anim.SetTrigger("hit");
        barraDeVidaDoJogador.value = vidasAtual;
        
        /*if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }*/
        if (vidasAtual <= 0)
        {
            Debug.Log("game over!");
        }
    }

    void OnCollisionEnter2D(Collision2D coll) // chamado todas as vezes que o player encosta em outro objeto com colisao
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ZonaDeMorte")
        {
            transform.position = respawnPoint;
        }
    }
}

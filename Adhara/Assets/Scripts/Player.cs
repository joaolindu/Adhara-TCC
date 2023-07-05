using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float jumpForce;

    /*private Vector2 teclasApertadas;*/
    
    private Rigidbody2D rig;

    private bool isJumping;
    private bool puloDuplo;

    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       movimentacao();
       pulo();
    }

    void movimentacao()
    {
        float movement = Input.GetAxis("Horizontal"); //se pressionar botao para a direita, valor max e 1 se pressionar para a esquerda valor max e -1
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y); //adiciona velocidade ao personagem no eixo x e y
        
        /*teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rig.velocity = teclasApertadas.normalized * velocidade;*/
        
        if (movement > 0) //se move para a direita
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movement < 0) //se move para a esquerda
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void pulo()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // "!" significa false ex: !isJumpg
            if (!isJumping) 
            {
                rig.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse); //adiciona forca
                puloDuplo = true;
                isJumping = true;
            }
            else
            {
                if (puloDuplo)
                {
                    rig.AddForce(new Vector2(0,jumpForce * 2),ForceMode2D.Impulse);
                    puloDuplo = false;
                }
            }

        }
        void OnCollisionEnter2D(Collision coll) // chamado todas as vezes que o player encosta em outro objeto
        {
            if (coll.gameObject.layer == 8)
            {
                isJumping = false;
            }
        }
    }
}

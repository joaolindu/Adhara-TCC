using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controles : MonoBehaviour
{ 
    public float velocidade;
    public float jumpForce;
    
    public float acceleration;
    public float slowdown;
    public float maxSpeed;
    private float inputDirection;
    private float direction;
    private float velocityX;

    private Rigidbody2D rig;
    
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        movimentacao();
        Jump();
        MovimentacaoGelo();
    }
    
    void movimentacao()
    {
        float movement = Input.GetAxis("Horizontal"); //se pressionar botao para a direita, valor max e 1 se pressionar para a esquerda valor max e -1
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y); //adiciona velocidade ao personagem no eixo x e y
    
        if (movement > 0) //se move para a direita
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    
        if (movement < 0) //se move para a esquerda
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void MovimentacaoGelo()
    {
        float movement = Input.GetAxis("Horizontal"); //se pressionar botao para a direita, valor max e 1 se pressionar para a esquerda valor max e -1
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y); //adiciona velocidade ao personagem no eixo x e y

        //if (Input.GetKeyDown())
        //{
            if (movement != 0)
            {
                if (velocityX <= 0)
                {
                    direction = Mathf.Sign(movement);
                }

                if (direction == Mathf.Sign(movement))
                {
                    velocityX += acceleration * Time.deltaTime * Mathf.Sign(movement);
                }
                else
                {
                    velocityX -= acceleration * Time.deltaTime * Mathf.Sign(movement);
                }
            }
        //}
        
        else
        {
            velocityX -= slowdown * Time.deltaTime * Mathf.Sign(velocityX);
        }
        // Limiditar a velocidade máxima
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        // Mover o objeto com a velocidade calculada
        transform.Translate(velocityX * Time.deltaTime, 0, 0);
    }
    
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            // "!" significa false ex: !isJumpg
            if (!isJumping) 
            {
                rig.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse); //adiciona forca
                isJumping = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll) // chamado todas as vezes que o player encosta em outro objeto com colisao
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}

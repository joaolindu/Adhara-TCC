using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoNoGelo : MonoBehaviour
{
    private Rigidbody2D rig;
    private float velocidade;
    public float acceleration;
    public float slowdown;
    public float maxSpeed;
    private float inputDirection;
    private float direction;
    private float velocityX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rig = FindObjectOfType<Controles>().rig;
        MovimentacaoGelo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MovimentacaoGelo()
    {
        float movement = Input.GetAxis("Horizontal"); //se pressionar botao para a direita, valor max e 1 se pressionar para a esquerda valor max e -1
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y); //adiciona velocidade ao personagem no eixo x e y
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

        else
        {
            velocityX -= slowdown * Time.deltaTime * Mathf.Sign(velocityX);
        }
        // Limiditar a velocidade máxima
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        // Mover o objeto com a velocidade calculada
        transform.Translate(velocityX * Time.deltaTime, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTE : MonoBehaviour
{
   public float acceleration = 5f;
   public float slowdown = 3f;

   private float inputDirection;
   private float direction;
   private float velocityX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /*// Ler a entrada do jogador (por exemplo, o eixo horizontal)
       inputDirection = Input.GetAxis("Horizontal");

       if (inputDirection != 0)
       {
          if (velocityX <= 0)
          {
             direction = inputDirection;
          }

          if (direction == inputDirection)
          {
             velocityX += acceleration * Time.deltaTime;
          }
          else
          {
             velocityX -= acceleration * Time.deltaTime;
          }
       }
       else
       {
          velocityX -= slowdown * Time.deltaTime;
       }

       // Limitar a velocidade máxima
       //velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

       // Mover o objeto com a velocidade calculada
       //transform.Translate(velocityX * Time.deltaTime, 0, 0);
    }*/
    }
    
}
    
/*if input_direction != 0:
     if velocity.x <= 0:
        direction = input_direction
        
     if direction == input_direction:
        velocity.x += ACELERATION * delta
     else:
        velocity.x -= ACELERATION * delta
else:
   velocity.x -=  SLOWDOWN * delta*/


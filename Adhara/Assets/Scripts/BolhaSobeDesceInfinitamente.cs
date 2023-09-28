using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaSobeDesceInfinitamente : MonoBehaviour
{
    public float alturaMaxima;
    public float velocidade;
    public float tempoDePausa;

    private bool movingUp = true;
    private Vector3 initialPosition;
    private float timer = 0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);

            if (transform.position.y >= initialPosition.y + alturaMaxima)
            {
                movingUp = false;
                timer = 0f;
            }
        }
        else
        {
            if (timer < tempoDePausa)
            {
                timer += Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.down * velocidade * Time.deltaTime);

                if (transform.position.y <= initialPosition.y)
                {
                    movingUp = true;
                    timer = 0f;
                }
            }
        }
    }
}

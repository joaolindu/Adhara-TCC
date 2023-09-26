using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformasSobeDesce : MonoBehaviour
{
    private bool moveDown;
    public int velociade;
    public Transform pontoA;
    public Transform pontoB;
    
   
    void Update()
    {
        if(transform.position.y > pontoA.position.y)
            moveDown = true;
        if (transform.position.y < pontoB.position.y)
            moveDown = false;
        if (moveDown)
            transform.position = new Vector2(transform.position.x, transform.position.y - velociade * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y + velociade * Time.deltaTime);

    }
}

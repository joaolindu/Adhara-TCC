using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarDirecao : MonoBehaviour
{
    private float inputHorizontal;
    public bool indoParaDireita;
    
    // Start is called before the first frame update
    void Start()
    {
        indoParaDireita = true;
    }

    // Update is called once per frame
    void Update()
    {
        receberInputs();
        verificarDirecaoInput();
    }
    private void receberInputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void verificarDirecaoInput()
    {
        if (inputHorizontal > 0)
        {
            indoParaDireita = true;
        }
        else if (inputHorizontal < 0)
        {
            indoParaDireita = false;
        }
    }
}

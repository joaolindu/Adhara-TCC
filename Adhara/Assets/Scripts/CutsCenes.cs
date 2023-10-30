using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsCenes : MonoBehaviour
{
    private string[] texto = new string[2];
    private GameObject falas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rotina());
        texto[0] = "adhara eh uma et";
        texto[1] = "que ama os pais!";

        falas = GameObject.Find("texto");
        falas.GetComponent<Text>().text = texto[0];
       
    }

    private int contador = 0;

    public IEnumerator Rotina()
    {
        //habilitar cena
        GameObject Cenas = GameObject.Find("img" + contador);
        Cenas.GetComponent<RawImage>().enabled = true;
        falas.GetComponent<Text>().text = texto[contador];
        contador++;
        
        //apagar anterior
        
        
        //
        if (contador < 3)
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(Rotina());
        }
        else
        {
            SceneManager.LoadScene("FaseEscura_1");
        }
    }
}

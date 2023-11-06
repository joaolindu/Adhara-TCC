using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsCenes : MonoBehaviour
{
    private string[] texto = new string[3];
    private GameObject falas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rotina());
        texto[0] = "Adhara é filha de pais exploradores do espaço...";
        texto[1] = "a jovem alienígena cresceu longe do planeta em que nasceu...";
        texto[2] = "agora, herdando o espírito de aventureira de seus parentes, decide percorrer um caminho repleto de perigos para saciar o desejo de conhecer o lugar que foi sua primeira casa...";

        falas = GameObject.Find("texto");
        falas.GetComponent<Text>().text = texto[0];
       
    }

    private int contador = 0;

    public IEnumerator Rotina()
    {
        GameObject Cenas = GameObject.Find("Cenas" + contador);
        Cenas.GetComponent<RawImage>().enabled = false;
        falas.GetComponent<Text>().text = texto[contador];
        contador++;
        
        if (contador < 3)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Rotina());
        }
        else
        {
            SceneManager.LoadScene("FaseEscura_1");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public string cenaPraCarregar;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(cenaPraCarregar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

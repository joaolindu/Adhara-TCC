using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroTeleguiadoDoInimigo : MonoBehaviour
{

    public GameObject bala;
    public float delay;

    public Transform localDeDisparo;
    public Transform _Player;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Atirar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TiroTeleguiado()
    {
        localDeDisparo.right = _Player.transform.position - transform.position;
        GameObject temporaria = Instantiate(bala, localDeDisparo.position, localDeDisparo.localRotation);
        temporaria.GetComponent<Rigidbody2D>().velocity = localDeDisparo.right * 3;
    }

    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(delay);
        TiroTeleguiado();
        StartCoroutine("Atirar");
    }
}

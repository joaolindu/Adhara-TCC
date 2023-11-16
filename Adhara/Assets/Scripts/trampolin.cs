using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour
{
    
    private Animator anim;
    public float forcaDoPulo;
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("pulo");
            EfeitosSonoros.instance.trampolim.Play();
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forcaDoPulo), ForceMode2D.Impulse);
        }
    }
}

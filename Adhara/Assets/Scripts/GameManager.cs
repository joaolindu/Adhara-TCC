using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform posicao;
    
    public static GameManager instance;
    
    
    [SerializeField] private string Menu;
    [SerializeField] private string Interface;
    [SerializeField] private string FaseEscura_1;
    //[SerializeField] private string FaseGelo_2;
    //[SerializeField] private string FaseMagma_3;
    
    private void Awake()
    {
       if (instance == null)
       {
         instance = this;
         DontDestroyOnLoad(this.gameObject);
       }
       else
       {
           Destroy(this.gameObject);
       }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(Menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cenas()
    {
        SceneManager.LoadScene(Interface);
        SceneManager.LoadSceneAsync(FaseEscura_1, LoadSceneMode.Additive).completed += delegate(AsyncOperation operation)
        {
            posicao = GameObject.FindWithTag("PlayerStart").transform;
            Instantiate(player, posicao.position, player.transform.rotation);
        };
        
        /*SceneManager.LoadScene(Interface);
        SceneManager.LoadSceneAsync(FaseGelo_2, LoadSceneMode.Additive).completed += delegate(AsyncOperation operation)
        {
            posicao = GameObject.FindWithTag("PlayerStart").transform;
            Instantiate(player, posicao.position, player.transform.rotation);
        };
        
        SceneManager.LoadScene(Interface);
        SceneManager.LoadSceneAsync(FaseMagma_3, LoadSceneMode.Additive).completed += delegate(AsyncOperation operation)
        {
            posicao = GameObject.FindWithTag("PlayerStart").transform;
            Instantiate(player, posicao.position, player.transform.rotation);
        };*/
    }

}
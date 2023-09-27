using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energia : MonoBehaviour
{
    public float maxEnergy = 100.0f; // Energia máxima do personagem
    public float currentEnergy; // Energia atual do personagem
    public float energyDecayRate = 5.0f; // Taxa de decaimento de energia por segundo
    public float energyRecoveryAmount = 20.0f; // Quantidade de energia recuperada ao coletar um objeto

    private void Start()
    {
        currentEnergy = maxEnergy; // Inicializa a energia no máximo
    }
    private void Update()
    {
        // Decaimento da energia com o tempo
        currentEnergy -= energyDecayRate * Time.deltaTime;

        // Verifica se a energia atingiu zero ou menos
        if (currentEnergy <= 0)
        {
            // Chama um método para tratar a morte do personagem e reiniciar a fase
            
            coletarEnergia();
            
        }
    }
    public void coletarEnergia()
    {
        currentEnergy += energyRecoveryAmount;

        // Certifique-se de que a energia não ultrapasse o máximo
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }
}

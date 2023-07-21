using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text healthText;

    public int balasColeta;
    //Quantidade de balas coletadas
    public Text texto_BalaColeta;
    //Exibe o texto com o número de coletas de balas.

    public static GameController instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int value)
    {
        balasColeta += value;
        texto_BalaColeta.text = balasColeta.ToString();
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }
}

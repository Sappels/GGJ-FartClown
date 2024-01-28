using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        int playerScore = PlayerPrefs.GetInt("score");
        int playerFarts = PlayerPrefs.GetInt("timesFarted");
        int playerPizzas = PlayerPrefs.GetInt("pizzasEaten");
        textMeshPro.text = "You Died \nYour Score: " + playerScore + "\nYou farted " + playerFarts + " times \n" + "You ate " + playerPizzas + " pizzas";



    }

    // Update is called once per frame
    void Update()
    {

    }
}

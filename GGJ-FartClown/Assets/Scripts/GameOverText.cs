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
        textMeshPro.text = "You Died \n Your Score:" + playerScore;



    }

    // Update is called once per frame
    void Update()
    {

    }
}

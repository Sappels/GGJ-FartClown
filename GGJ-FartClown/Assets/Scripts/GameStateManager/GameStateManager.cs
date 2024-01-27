using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text m_timerUI;

    public int keysMissed = 0;
    public int timesFarted = 0;
    public int pizzasEaten = 0;
    public float score = 0;
    public float fartMeterValue = 0;

    public Slider fartMeterSlider;

    public static GameStateManager Instance { get; private set; }

    //public GameState currState = GameState.ENTRY;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void FillUpFarts()
    {
        float n = Random.Range(0.3f, 0.4f);
        fartMeterValue += n;
        fartMeterSlider.value = fartMeterValue;
        if (n >= 1f)
        {
            //Show fartbutton!
        }
    }

    public void ResetFarts()
    {
        fartMeterValue = 0;
    }

    public void AddScore(float reactionTime, float fillSpeed)
    {
        float threshold = fillSpeed * 0.25f;
        FillUpFarts();
        if (reactionTime <= threshold)
            score += 125;
        else
            score += 100;
    }

    public void MissedKey()
    {
        keysMissed++;
        if (keysMissed >= 3) GameOver();
    }

    public void ResetKeysMissed()
    {
        keysMissed = 0;
    }

    public void GameOver()
    {
        //Call this method when a loss condition has been met
        //Shows a Game Over screen with pizzas eaten, times farted and score
    }


    // Start is called before the first frame update

    //public void YouWin()
    //{
    //    GameStateManager.Instance.currState = GameState.WIN;
    //    m_timerUI.text = "YOU Win!";
    //    Debug.Log("You Win!");
    //
    //}
    // public void Update()
    // {
    //     if (currState == GameState.RUNNING)
    //     {
    //         Running();
    //     }
    // }
    // public void Running()
    // {
    //     m_timer -= Time.deltaTime;
    //     m_timerUI.text = "YOU Win!";


    //     if (m_timer < 0)
    //         FailedStage();
    // }
    //public void YouLose()
    //{
    //    GameStateManager.Instance.currState = GameState.LOOSE;
    //    m_timerUI.text = "YOU LOOSE!";
    //
    //    Debug.Log("You Lose!");
    //}


}
//public enum GameState
//{
//    ENTRY,
//    WIN,
//    LOOSE,
//    RUNNING
//}
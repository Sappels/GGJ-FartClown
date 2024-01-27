using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text m_timerUI;

    public static GameStateManager Instance { get; private set; }

    public GameState currState = GameState.ENTRY;
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

    // Start is called before the first frame update

    public void YouWin()
    {
        GameStateManager.Instance.currState = GameState.WIN;
        m_timerUI.text = "YOU Win!";
        Debug.Log("You Win!");

    }
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
    public void YouLose()
    {
        GameStateManager.Instance.currState = GameState.LOOSE;
        m_timerUI.text = "YOU LOOSE!";

        Debug.Log("You Lose!");
    }


}
public enum GameState
{
    ENTRY,
    WIN,
    LOOSE,
    RUNNING
}
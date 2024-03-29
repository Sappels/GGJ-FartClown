using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text m_timerUI;

    public int keysMissed = 0;
    public int timesFarted = 0;
    public int pizzasEaten = 0;
    public int score = 0;
    public float fartMeterValue = 0;

    public GameObject missedPrefab;
    public GameObject clown;
    public GameObject clownBlowUpPlaceholder;
    public Transform missedKeySpawnPoint;
    public Slider fartMeterSlider;
    public Animator animator;

    public static GameStateManager Instance { get; private set; }

    public GameObject stomach;

    //public GameState currState = GameState.ENTRY;
    void Awake()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("timesFarted", 0);
        PlayerPrefs.SetInt("pizzasEaten", 0);
        PlayerPrefs.SetString("howDidIDie", "");

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
        float n = Random.Range(0.4f, 0.6f);
        fartMeterValue += n;
        fartMeterSlider.value = fartMeterValue;
        AudioManager.Instance.PlayInflateSound();
        if (fartMeterValue >= 0.95f) fartMeterValue = 1f;
        if (fartMeterValue >= 1f)
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.areYouReady);
            FartManager.Instance.UrgeToFart(3);
        }
    }

    public void LateUpdate()
    {
        stomach.transform.localScale = new Vector3(
               1 + 0.5f * fartMeterValue,
               stomach.transform.localScale.y,
               stomach.transform.localScale.z
               );
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

    public void InstantiateAnnoyance()
    {
        AudioManager.Instance.PlayDohSound();
        Instantiate(missedPrefab, missedKeySpawnPoint);
    }
    public void MissedKey()
    {
        InstantiateAnnoyance();

        keysMissed++;
        if (keysMissed >= 3)
        {
            Choking();
            Invoke("GameOver", 3f);

        }
        else
        {
            ComboManager.Instance.GenerateCombo(ComboManager.Instance.FillSpeed);
        }
    }

    public void ResetKeysMissed()
    {
        keysMissed = 0;
    }

    public void BlowUp()
    {
        Debug.Log("Blowing up");
        clown.SetActive(false);
        clownBlowUpPlaceholder.SetActive(true);

        Debug.Log("Blowing up:GameOver");
        PlayerPrefs.SetString("howDidIDie", "pop");
        Invoke("GameOver", 1.5f);
        // GameOver();

    }
    public void Choking()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.cough);
        PlayerPrefs.SetString("howDidIDie", "choke");
        animator.Play("Choking");
    }

    public void GameOver()
    {
        Debug.Log("You lost!");
        //Time.timeScale = 0;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("timesFarted", timesFarted);
        PlayerPrefs.SetInt("pizzasEaten", pizzasEaten);

        SceneManager.LoadScene("GameOver");

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    // public static MainScreenManager Instance { get; private set; }

    public GameObject credits;

    public GameObject pop;
    public GameObject choke;

    // Start is called before the first frame update
    void Start()
    {
        // if (Instance != null && Instance != this)
        // {
        //     Destroy(this);
        // }
        // else
        // {
        //     Instance = this;
        // }

        if (SceneManager.GetActiveScene().name == "Start") return;
        switch (PlayerPrefs.GetString("howDidIDie"))
        {
            case "pop":
                pop.SetActive(true);
                choke.SetActive(false);
                break;
            case "choke":
                pop.SetActive(false);
                choke.SetActive(true);
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    public void XPressed(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
    }

    public void ActivateCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

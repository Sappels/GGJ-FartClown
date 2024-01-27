using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenManager : MonoBehaviour
{
    // public static MainScreenManager Instance { get; private set; }

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
    }

    // Update is called once per frame
    public void XPressed(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
    }
}

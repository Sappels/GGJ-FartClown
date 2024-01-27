using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartManager : MonoBehaviour
{
    [SerializeField] private KeySpawner keySpawner;

    public static FartManager Instance { get; private set; }
    public GameObject FartPrefab;
    public Transform Butt;
    // Start is called before the first frame update
    void Awake()
    {
        keySpawner = gameObject.GetComponent<KeySpawner>();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ReleaseTheGasss();
        // }
    }
    public void ReleaseTheGasss()
    {
        keySpawner.DestroyFartKey();
        Instantiate(FartPrefab, Butt);
        GameStateManager.Instance.fartMeterValue = 0;
        GameStateManager.Instance.fartMeterSlider.value = 0;
        GameStateManager.Instance.ResetKeysMissed();
        //Release in gameState
    }

    public void UrgeToFart(float FillSpeed)
    {
        keySpawner.SpawnFart(FillSpeed);

    }
    public void PumpInSomeGassy(float gas)
    {
        //Add in gameState

    }
}

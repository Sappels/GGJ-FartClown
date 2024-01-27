using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartManager : MonoBehaviour
{
    public static FartManager Instance { get; private set; }
    public GameObject FartPrefab;
    public Transform Butt;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FartPrefab, Butt);
            ReleaseTheGasss();
        }
    }
    public void ReleaseTheGasss()
    {
        //Release in gameState
    }
    public void PumpInSomeGassy(float gas)
    {
        //Add in gameState

    }
}

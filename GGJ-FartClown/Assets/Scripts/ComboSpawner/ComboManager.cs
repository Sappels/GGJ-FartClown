using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public static ComboManager Instance { get; private set; }

    public float FillSpeed = 5f;
    public KeySpawner keySpawner;
    public float lastSpawnTime = 0;
    public KeyCode currKey;
    public StageRunner stageRunner;
    // Start is called before the first frame update
    void Awake()
    {
        stageRunner = GetComponent<StageRunner>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        keySpawner = gameObject.GetComponent<KeySpawner>();
    }
    void Start()
    {

    }

    public void GenerateCombo(float newFillSpeed)
    {
        KeyCode[] AvailableKeys = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V };
        int newKeyIndex = Random.Range(0, AvailableKeys.Length);
        currKey = AvailableKeys[newKeyIndex];
        FillSpeed = newFillSpeed;
        SpawnNextKey(FillSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateSpeed()
    {
        float reactionTime = Time.time - lastSpawnTime;
        // Debug.Log("Reacted in " + reactionTime);
    }
    public void VerifyKey(KeyCode keyDown)
    {
        if (keyDown == currKey)
        {
            Debug.Log("Got a new key");
            CalculateSpeed();
            bool didNewPizzaSpawn = stageRunner.EatPizzaSlice();
            keySpawner.CorrectKey();
            Debug.Log("Called in Verify");
            GenerateCombo(FillSpeed);
        }
    }

    public void SpawnNextKey(float FillSpeed)
    {
        lastSpawnTime = Time.time;
        keySpawner.SpawnKey(currKey.ToString(), FillSpeed);
    }

    public void WinCondition()
    {
        //Commented this out because it was causing an error and we don't need to call for "win" anyway // Viktor
        //GameStateManager.Instance.YouWin();
        // GenerateCombo();
    }
}

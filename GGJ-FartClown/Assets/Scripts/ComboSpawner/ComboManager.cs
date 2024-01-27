using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public static ComboManager Instance { get; private set; }

    public float FillSpeed = 5f;
    public KeySpawner keySpawner;
    public float lastSpawnTime = 0;
    public KeyCode[] Combo;
    public KeyCode currKey;
    public int currIndex = 0;
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

        //CauseKeySpawner is called and array starts with 0
        // currIndex = -1;
        // GenerateCombo();
        // SpawnNextKey(FillSpeed);
    }

    public void GenerateCombo(int length, float newFillSpeed)
    {
        FillSpeed = newFillSpeed;
        // ReduceFillSpeed()
        KeyCode[] AvailableKeys = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V };
        List<KeyCode> randomElements = new List<KeyCode>();
        for (int i = 0; i < length; i++)
        {
            int randomIndex = Random.Range(0, AvailableKeys.Length);
            randomElements.Add(AvailableKeys[randomIndex]);
        }

        Combo = randomElements.ToArray();
        currIndex = -1;
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
        if (currIndex < Combo.Length && keyDown == Combo[currIndex])
        {
            Debug.Log("Got a new key");
            CalculateSpeed();
            stageRunner.EatPizzaSlice();
            keySpawner.CorrectKey();

            SpawnNextKey(FillSpeed);
        }
    }

    public void SpawnNextKey(float FillSpeed)
    {
        lastSpawnTime = Time.time;
        currIndex++;
        if (currIndex < Combo.Length)
        {
            Debug.Log("Spawning new key at index: " + currIndex + "" + Combo[currIndex] + "==" + string.Join(", ", Combo));
            keySpawner.SpawnKey(Combo[currIndex].ToString(), FillSpeed);
        }
    }

    public void WinCondition()
    {
        //Commented this out because it was causing an error and we don't need to call for "win" anyway // Viktor
        //GameStateManager.Instance.YouWin();
        // GenerateCombo();
    }
}

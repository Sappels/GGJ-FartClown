using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public static ComboManager Instance { get; private set; }
    public KeySpawner keySpawner;
    public float lastSpawnTime = 0;
    public KeyCode[] Combo;
    public KeyCode currKey;
    public int currIndex = 0;
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

        keySpawner = gameObject.GetComponent<KeySpawner>();
    }
    void Start()
    {

        //CauseKeySpawner is called and array starts with 0
        currIndex = -1;
        GenerateCombo();
        SpawnNextKey();
    }

    void GenerateCombo()
    {
        currIndex = 0;
        Combo = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V };
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Combo[currIndex]))
        {
            CalculateSpeed();
            SpawnNextKey();
        }
    }

    public void CalculateSpeed()
    {
        float reactionTime = Time.time - lastSpawnTime;
        Debug.Log("Reacted in " + reactionTime);
    }
    public void VerifyKey(KeyCode keyDown)
    {
        if (keyDown == Combo[currIndex])
        {
            SpawnNextKey();
        }
    }

    public void SpawnNextKey()
    {
        keySpawner.DestroyKey();
        lastSpawnTime = Time.time;
        currIndex++;
        if (Combo.Length == currIndex)
        {
            WinCondition();
        }
        else
        {
            Debug.Log("Spawning new key at index: " + currIndex + "" + Combo[currIndex]);
            keySpawner.SpawnKey(Combo[currIndex].ToString());
        }
    }

    public void WinCondition()
    {
        GameStateManager.Instance.YouWin();
        GenerateCombo();
    }
}

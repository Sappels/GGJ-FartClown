using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeySpawner : MonoBehaviour
{
    // public static KeySpawner Instance { get; private set; }
    public Transform keySpawnPoint;
    public GameObject spawnedKey;
    public GameObject keyPrefab;
    public GameObject Success;

    public void CorrectKey()
    {
        Instantiate(Success, keySpawnPoint);
        DestroyKey();
    }
    public void WrongKey()
    {
        DestroyKey();

    }
    public void DestroyKey()
    {
        Destroy(spawnedKey);
        spawnedKey = null;
    }
    public void SpawnKey(string KeyName)
    {
        if (spawnedKey != null)
        {
            DestroyKey();
        }

        spawnedKey = Instantiate(keyPrefab.gameObject, keySpawnPoint);
        GameObject textObj = spawnedKey.transform.Find("Canvas/Key").gameObject;

        textObj.GetComponent<TMPro.TMP_Text>().text = KeyName;

    }
}

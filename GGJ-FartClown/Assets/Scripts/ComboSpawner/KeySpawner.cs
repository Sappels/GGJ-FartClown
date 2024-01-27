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
        Debug.Log(spawnedKey);
        GameObject textObj = spawnedKey.transform.Find("Key").gameObject;
        Debug.Log(textObj);

        textObj.GetComponent<TMPro.TMP_Text>().text = KeyName;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeySpawner : MonoBehaviour
{
    // public static KeySpawner Instance { get; private set; }
    public Transform keySpawnPoint;
    public Transform FartSpawnPoint;
    public GameObject Fart;
    public GameObject FartPrefab;
    public GameObject spawnedKey;
    public GameObject keyPrefab;
    public GameObject Success;

    //public GameObject currentKey;

    ComboManager comboManager;

    public Sprite z, x, c, v, fart;


    private void Start()
    {
        comboManager = GetComponent<ComboManager>();
    }

    public void CorrectKey()
    {
        Instantiate(Success, keySpawnPoint);
    }
    public void WrongKey()
    {
        GameStateManager.Instance.MissedKey();
    }
    public void DestroyKey()
    {
        Destroy(spawnedKey);
        //Here we need to spawn a new key, getting stackoverflow when calling combomanager
        spawnedKey = null;
    }

    public void DestroyFartKey()
    {
        if (Fart)
        {
            Destroy(Fart);
            Fart = null;
        }
    }

    public void SpawnFart(float keySpeed)
    {
        Fart = Instantiate(FartPrefab.gameObject, FartSpawnPoint);
        //Fart.GetComponent<KeyClass>().Key = "Space";
        Fart.GetComponent<KeyClass>().FillSpeed = keySpeed;
        // GameObject textObj = spawnedKey.transform.Find("Canvas/Key").gameObject;
        GameObject imageObj = Fart.transform.Find("Canvas/KeyImage").gameObject;
        imageObj.GetComponent<Image>().sprite = fart;

    }
    public void SpawnKey(string KeyName, float keySpeed)
    {
        if (spawnedKey != null)
        {
            DestroyKey();
        }


        spawnedKey = Instantiate(keyPrefab.gameObject, keySpawnPoint);
        spawnedKey.GetComponent<KeyClass>().Key = KeyName;
        spawnedKey.GetComponent<KeyClass>().FillSpeed = keySpeed;
        // GameObject textObj = spawnedKey.transform.Find("Canvas/Key").gameObject;
        GameObject imageObj = spawnedKey.transform.Find("Canvas/KeyImage").gameObject;

        // textObj.GetComponent<TMPro.TMP_Text>().text = KeyName;

        switch (KeyName)
        {
            case "Z":
                imageObj.GetComponent<Image>().sprite = z;
                break;
            case "X":
                imageObj.GetComponent<Image>().sprite = x;
                break;
            case "C":
                imageObj.GetComponent<Image>().sprite = c;
                break;
            case "V":
                imageObj.GetComponent<Image>().sprite = v;
                break;

            default:
                break;
        }


    }
}

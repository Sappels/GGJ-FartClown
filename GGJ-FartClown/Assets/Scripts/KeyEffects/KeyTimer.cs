using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTimer : MonoBehaviour
{

    public GameObject parent;
    public KeyClass Key;
    public Image TimerImage;
    public float FilledAmount = 1;
    // public float FillSpeed = 5f;
    public float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        TimerImage = GetComponent<Image>();
        SpawnTime = Time.time;
        Key = parent.GetComponent<KeyClass>();
    }

    // Update is called once per frame
    void Update()
    {


        FilledAmount = ((SpawnTime + Key.FillSpeed) - Time.time) / Key.FillSpeed;
        TimerImage.fillAmount = FilledAmount;

        //Can be Removed 
        if ((Time.time - SpawnTime) > Key.FillSpeed)
        {
            Destroy(gameObject);
            if (Key.Key == "Space")
            {
                GameStateManager.Instance.BlowUp();
                AudioManager.Instance.PlaySound(AudioManager.Instance.pop);
            }
            else
            {
                GameStateManager.Instance.gameObject.GetComponent<KeySpawner>().DestroyKey();
                GameStateManager.Instance.MissedKey();
            }
            //GameStateManager.Instance.YouLose();
        }

    }


}

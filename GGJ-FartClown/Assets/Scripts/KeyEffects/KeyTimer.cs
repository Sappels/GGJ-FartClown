using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTimer : MonoBehaviour
{

    public Image TimerImage;
    public float FilledAmount = 1;
    public float FillSpeed = 5f;
    public float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        TimerImage = GetComponent<Image>();
        SpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        FilledAmount = ((SpawnTime + FillSpeed) - Time.time) / FillSpeed;
        TimerImage.fillAmount = FilledAmount;

        //Can be Removed 
        if ((Time.time - SpawnTime) > 5)
        {
            Destroy(gameObject);
            GameStateManager.Instance.YouLose();
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessEffect : MonoBehaviour
{
    public float offTime = 1;




    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, offTime);
    }
}

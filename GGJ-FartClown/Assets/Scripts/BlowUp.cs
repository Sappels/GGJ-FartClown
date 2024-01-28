using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Rigidbody[] bodyParts = gameObject.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < bodyParts.Length; i++)
        {
            Vector3 direction = Random.insideUnitSphere.normalized;
            Debug.Log(bodyParts[i].gameObject.name);
            float forceMagnitude = Random.Range(5, 10);
            if (bodyParts[i] != null)
                bodyParts[i].AddForce(Random.insideUnitSphere.normalized * forceMagnitude, ForceMode.Impulse);
            else
                Debug.Log("No Rigidbody found");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

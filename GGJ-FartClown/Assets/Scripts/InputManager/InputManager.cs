using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // GetComponent<Animator>().SetTrigger("Fart");
            FartManager.Instance.ReleaseTheGasss();
        }
        if (Input.GetKeyDown(KeyCode.Z))

        {
            ComboManager.Instance.VerifyKey(KeyCode.Z);
        }
        if (Input.GetKeyDown(KeyCode.X))

        {
            ComboManager.Instance.VerifyKey(KeyCode.X);
        }
        if (Input.GetKeyDown(KeyCode.C))

        {
            ComboManager.Instance.VerifyKey(KeyCode.C);
        }
        if (Input.GetKeyDown(KeyCode.V))

        {
            ComboManager.Instance.VerifyKey(KeyCode.V);
        }


    }
}

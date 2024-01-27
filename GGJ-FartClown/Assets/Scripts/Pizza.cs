using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_PizzaSlices = new List<GameObject>();

    public bool EatSlice()
    {
        if (m_PizzaSlices.Count > 0)
        {
            int randomSlice = Random.Range(0, m_PizzaSlices.Count);
            m_PizzaSlices[randomSlice].SetActive(false);
            m_PizzaSlices.RemoveAt(randomSlice);
        }
        Debug.Log("Slices left" + m_PizzaSlices.Count);

        return m_PizzaSlices.Count > 0 ? true : false;
    }
}

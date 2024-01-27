using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class StageRunner : MonoBehaviour
{
    [SerializeField] private float FillSpeed = 5f;
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private Pizza m_pizzaPrefab;

    private Pizza m_activePizza;

    private void Start()
    {
        GameStateManager.Instance.currState = GameState.RUNNING;
        PlacePizzas();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            EatPizzaSlice();
    }

    public void EatPizzaSlice()
    {
        bool state = m_activePizza.EatSlice();
        if (!state)
        {
            m_activePizza.EatSlice();
        }
        else
        {
            PlacePizzas();
        }
    }

    private void PlacePizzas()
    {
        if (FillSpeed > 0.5f)
        {
            FillSpeed -= 0.25f;
        }

        Vector3 startSpawnPoint = m_spawnPoint.position;
        m_activePizza = Instantiate(m_pizzaPrefab);
        m_activePizza.transform.position = startSpawnPoint;
        
        ComboManager.Instance.GenerateCombo(6, FillSpeed);

    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using UnityEngine.SceneManagement;
// using Unity.VisualScripting;
// using System;

// public class StageRunner : MonoBehaviour
// {
//     [SerializeField] private List<Stage> stages = new List<Stage>();
//     [SerializeField] private Transform m_spawnPoint;
//     [SerializeField] private TMPro.TMP_Text m_timerUI;
//     [SerializeField] private float m_spaceBetweenPizzas;
//     [SerializeField] private Pizza m_pizzaPrefab;

//     private float m_timer;
//     private int m_stageNumber = 0;


//     private Pizza m_activePizza;
//     private int m_pizzaNumber = 0;

//     public List<Pizza> m_pizzas = new List<Pizza>();

//     private void Start()
//     {
//         SetUpNextStage();
//     }

//     private void Update()
//     {
//         m_timer -= Time.deltaTime;
//         m_timerUI.text = "Time: " + m_timer.ToString("F2");

//         if (m_timer < 0)
//             FailedStage();

//         if (Input.GetKeyDown(KeyCode.P))
//             EatPizzaSlice();
//     }

//     public void EatPizzaSlice()
//     {
//         if (!m_activePizza.EatSlice())
//         {
//             m_pizzaNumber++;

//             if (m_pizzas.Count > m_pizzaNumber)
//             {
//                 m_activePizza = m_pizzas[m_pizzaNumber];
//                 m_activePizza.EatSlice();
//             }
//             else
//             {
//                 SetUpNextStage();
//             }
//         }
//     }


//     private bool SetUpNextStage()
//     {
//         if (stages.Count < m_stageNumber + 1)
//         {
//             // Win
//             return false;
//         }

//         CleanUpStagesPizzas();

//         Stage stage = stages[m_stageNumber];
//         m_timer = stage.Time;
//         PlacePizzas(stage.Pizzas);

//         m_stageNumber++;

//         return true;
//     }

//     private void CleanUpStagesPizzas()
//     {
//         foreach (Pizza pizza in m_pizzas)
//         {
//             pizza.gameObject.SetActive(false);
//         }

//         m_pizzas.Clear();
//         m_pizzaNumber = 0;
//     }

//     // Spawn pizzas starting from the left, then spawn them in sequence from left to right
//     private void PlacePizzas(int numberOffPizzas)
//     {
//         float startSpawnPointLeft = m_spawnPoint.position.x - ((numberOffPizzas / 2) * m_spaceBetweenPizzas);
//         Vector3 startSpawnPoint = new Vector3(startSpawnPointLeft, m_spawnPoint.position.y, m_spawnPoint.position.z);

//         for (int i = 0; i < numberOffPizzas; i++)
//         {
//             Pizza pizza = Instantiate(m_pizzaPrefab);
//             pizza.transform.position = startSpawnPoint + Vector3.right * m_spaceBetweenPizzas * i;
//             m_pizzas.Add(pizza);
//         }

//         m_activePizza = m_pizzas[m_pizzaNumber];
//     }


//     public void FailedStage()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }

//     [Serializable]
//     private struct Stage
//     {
//         public float Time;
//         public int Pizzas;
//     }
// }

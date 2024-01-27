using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class StageRunner : MonoBehaviour
{
    [SerializeField] private List<Stage> stages = new List<Stage>();
    [SerializeField] private Transform m_spawnPoint;
    [SerializeField] private TMPro.TMP_Text m_timerUI;
    [SerializeField] private float m_spaceBetweenPizzas;
    [SerializeField] private Pizza m_pizzaPrefab;

    private float m_timer;
    private int m_stageNumber = 1;

    public List<Pizza> m_pizzas = new List<Pizza>();

    private void Start()
    {
        SetUpNextStage();
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;
        m_timerUI.text = "Time: " + m_timer.ToString("F2");

        if (m_timer < 0)
            FailedStage();

        if (Input.GetKeyDown(KeyCode.P))
            SetUpNextStage();
    }

    private bool SetUpNextStage()
    {
        if (stages.Count < m_stageNumber)
            return false;

        Stage stage = stages[m_stageNumber - 1];
        m_timer = stage.Time;
        PlacePizzas(stage.Pizzas);
        m_stageNumber++;

        return true;
    }

    // Spawn pizzas starting from the left, then spawn them in sequence from left to right
    private void PlacePizzas(int numberOffPizzas)
    {
        float startSpawnPointLeft = m_spawnPoint.position.x - ((numberOffPizzas / 2) * m_spaceBetweenPizzas);
        Vector3 startSpawnPoint = new Vector3(startSpawnPointLeft, m_spawnPoint.position.y, m_spawnPoint.position.z);

        for (int i = 0; i < numberOffPizzas; i++)
        {
            Pizza pizza = Instantiate(m_pizzaPrefab);
            pizza.transform.position = startSpawnPoint + Vector3.right * m_spaceBetweenPizzas * i;
            m_pizzas.Add(pizza);
        }

    }


    public void FailedStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [Serializable]
    private struct Stage
    {
        public float Time;
        public int Pizzas;
    }
}

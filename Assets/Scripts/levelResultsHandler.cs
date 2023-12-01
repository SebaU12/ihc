using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelResultsHandler : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool isTimerRunning;
    public GameObject tporter;

    void Start()
    {

        tporter.SetActive(false);
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime = Time.time - startTime;
        }
        if (elapsedTime > 10 && isTimerRunning == true)
        {
            tporter.SetActive(true);
            StopTimer();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log("Temporizador detenido. Tiempo total: " + elapsedTime.ToString("F2") + " segundos");
    }
}

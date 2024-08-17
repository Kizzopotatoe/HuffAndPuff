using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI timerTextWhenCompleted;

    private float currentTime;
    private float startingTime;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        // During the game
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");

        // When level has been completed
        timerTextWhenCompleted.text = currentTime.ToString("0.00");
    }
}

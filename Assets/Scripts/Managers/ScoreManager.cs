using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Timer Logic")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTextWhenCompleted;
    public TextMeshProUGUI secondsText;
    public TextMeshProUGUI minutesText;

    private float currentTime;
    private float startingTime;

    [Header("Collectables Logic")]
    public TextMeshProUGUI collectablesText;
    public TextMeshProUGUI collectablesTextWhenCompleted;


    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        Timer();

        if (GameManager.Instance.hasCompletedLevel)
        {
            collectablesText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
        }
    }

    private void Timer()
    {
        // During the game
        currentTime += Time.deltaTime;

        // Checks if the current time is 60 seconds or less 
        if (currentTime < 60f)
        {
            // Format time as seconds
            timerText.text = currentTime.ToString("0.00");
            timerTextWhenCompleted.text = currentTime.ToString("0.00");
        }
        else
        {
            // When time exceeds 60 seconds, format time in minutes and seconds
            float minutes = Mathf.Floor(currentTime / 59); // divide by 59 so it doesn't count the 60 seconds so it looks like this (e.g. 3:60)
            float seconds = currentTime % 59;

            timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
            timerTextWhenCompleted.text = string.Format("{0}:{1:00}", minutes, seconds);

            // Change default "seconds" text to "minutes"
            minutesText.gameObject.SetActive(true);
            secondsText.gameObject.SetActive(false);
        }


    }

    public void Collectables(int collectables)
    {
        // During the game
        collectablesText.text = collectables.ToString();

        // When level has been completed
        collectablesTextWhenCompleted.text = collectables.ToString();
    }
}

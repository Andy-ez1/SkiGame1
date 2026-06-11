using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();
    public delegate void TimerPenaltyEvent(float penaltyTime);

    public static event System.Action OnLeaderboardChanged;

    private bool isRacing = false;
    private float raceTime = 0;

    [SerializeField] private TMP_Text timeText, bestTimeText;
    [SerializeField] private string bestTimeKey = "LVL1_BEST_TIME";

    private float bestTime = 99.99f;

    private void Start()
    {
        bestTime = Leaderboard.GetBestTime(bestTimeKey, 99.99f);
        bestTimeText.text = "BEST TIME: " + bestTime.ToString("F2");
        OnLeaderboardChanged?.Invoke();
    }

    private void OnEnable()
    {
        StartGate.TimerStart += StartTimer;
        FinishGate.TimerEnd += StopTimer;
        SlalomFlag.Penalty += AddPenalty;
    }

    private void OnDisable()
    {
        StartGate.TimerStart -= StartTimer;
        FinishGate.TimerEnd -= StopTimer;
        SlalomFlag.Penalty -= AddPenalty;
    }

    private void AddPenalty(float penalty)
    {
        raceTime += penalty;
        Debug.Log("Received penalty: +" + penalty);
    }

    private void StartTimer()
    {
        Debug.Log("started timer");
        isRacing = true;
    }

    private void StopTimer()
    {
        Debug.Log("stopped timer. Race time: " + raceTime);
        isRacing = false;

        bool newRecord = raceTime < bestTime;

        Leaderboard.AddTime(bestTimeKey, raceTime);

        bestTime = Leaderboard.GetBestTime(bestTimeKey, 99.99f);
        bestTimeText.text = "BEST TIME: " + bestTime.ToString("F2");
        if (newRecord)
            bestTimeText.color = Color.yellow;

        OnLeaderboardChanged?.Invoke();

        Invoke("RestartScene", 3);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (isRacing)
            raceTime += Time.deltaTime;

        timeText.text = "TIME: " + raceTime.ToString("F2");
    }
}
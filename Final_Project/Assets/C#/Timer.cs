using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public string nextSceneName;

    private float startTime;
    private bool isTiming;
    private static Timer instance;
    private float additionalTime;

    public enum GameType { ChickenRice, MeatBalls, PineappleCake, ScallionPancake }
    public GameType currentGame;

    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Timer>();
                if (instance == null)
                {
                    GameObject timerObject = new GameObject("Timer");
                    instance = timerObject.AddComponent<Timer>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        if (!isTiming && !GetGamePlayed(currentGame))
        {
            ResetTimer();
        }
        else if (GetGamePlayed(currentGame))
        {
            ResumeTimer();
        }
    }

    void Update()
    {
        if (isTiming)
        {
            UpdateTimer();
        }
    }

    public void StartTimer()
    {
        startTime = Time.time - GetTotalTime(currentGame);
        isTiming = true;
        additionalTime = 0f;
    }

    public void StopTimer()
    {
        isTiming = false;
        SetTotalTime(currentGame, (Time.time - startTime) + additionalTime);
        SetGamePlayed(currentGame, true);
    }

    private void UpdateTimer()
    {
        float totalTime = (Time.time - startTime) + additionalTime;
        string minutes = ((int)totalTime / 60).ToString("00");
        string seconds = (totalTime % 60).ToString("00.00");
        //SetTotalTime(currentGame, totalTime);
        if (timerText != null)
        {
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void PauseTimer()
    {
        isTiming = false;
    }

    public void ResumeTimer()
    {
        startTime = Time.time - GetTotalTime(currentGame);
        isTiming = true;
    }

    public void UpdateTimerTextReference(TMP_Text newTimerText)
    {
        timerText = newTimerText;
        UpdateTimer(); // 确保新的文本组件立即显示当前时间
    }

    public void AddTime(float extraTime)
    {
        additionalTime += extraTime;
    }

    public void ResetTimer()
    {
        SetTotalTime(currentGame, 0);
        additionalTime = 0;
        startTime = Time.time;
        isTiming = true;
        UpdateTimer();
    }

    private float GetTotalTime(GameType game)
    {
        switch (game)
        {
            case GameType.ChickenRice:
                return MedalManager.chickenriceTotalTime;
            case GameType.MeatBalls:
                return MedalManager.meatBallsTotalTime;
            case GameType.PineappleCake:
                return MedalManager.pineappleCakeTotalTime;
            case GameType.ScallionPancake:
                return MedalManager.scallionPancakeTotalTime;
            default:
                return 0;
        }
    }

    private void SetTotalTime(GameType game, float time)
    {
        switch (game)
        {
            case GameType.ChickenRice:
                MedalManager.chickenriceTotalTime = time;
                break;
            case GameType.MeatBalls:
                MedalManager.meatBallsTotalTime = time;
                break;
            case GameType.PineappleCake:
                MedalManager.pineappleCakeTotalTime = time;
                break;
            case GameType.ScallionPancake:
                MedalManager.scallionPancakeTotalTime = time;
                break;
        }
    }

    private bool GetGamePlayed(GameType game)
    {
        switch (game)
        {
            case GameType.ChickenRice:
                return MedalManager.chickenriceGamePlayed;
            case GameType.MeatBalls:
                return MedalManager.meatBallsGamePlayed;
            case GameType.PineappleCake:
                return MedalManager.pineappleCakeGamePlayed;
            case GameType.ScallionPancake:
                return MedalManager.scallionPancakeGamePlayed;
            default:
                return false;
        }
    }

    private void SetGamePlayed(GameType game, bool played)
    {
        switch (game)
        {
            case GameType.ChickenRice:
                MedalManager.chickenriceGamePlayed = played;
                break;
            case GameType.MeatBalls:
                MedalManager.meatBallsGamePlayed = played;
                break;
            case GameType.PineappleCake:
                MedalManager.pineappleCakeGamePlayed = played;
                break;
            case GameType.ScallionPancake:
                MedalManager.scallionPancakeGamePlayed = played;
                break;
        }
    }
}

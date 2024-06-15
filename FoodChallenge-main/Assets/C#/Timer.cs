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

        if (!isTiming && !MedalManager.GamePlayed)
        {
            StartTimer();
        }
        else if (MedalManager.GamePlayed)
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
        startTime = Time.time - MedalManager.TotalTime;
        isTiming = true;
        additionalTime = 0f;
    }

    public void StopTimer()
    {
        isTiming = false;
        MedalManager.TotalTime = Time.time - startTime;
        MedalManager.GamePlayed = true;
    }

    private void UpdateTimer()
    {
        float totalTime = (Time.time - startTime) + additionalTime;
        string minutes = ((int)totalTime / 60).ToString("00");
        string seconds = (totalTime % 60).ToString("00.00");
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
        startTime = Time.time - MedalManager.TotalTime;
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
}

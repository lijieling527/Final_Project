using UnityEngine;

public class MedalManager : MonoBehaviour
{
    public static MedalManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 其他方法和数据管理逻辑
    public static bool chickenriceGamePlayed { get; set; } = false;
    public static float chickenriceTotalTime { get; set; } = 0;
    public static bool chickenriceGamePass { get; set; } = false;

    public static bool meatBallsGamePlayed { get; set; } = false;
    public static float meatBallsTotalTime { get; set; } = 0;
    public static bool meatBallsGamePass { get; set; } = false;

    public static bool pineappleCakeGamePlayed { get; set; } = false;
    public static float pineappleCakeTotalTime { get; set; } = 0;
    public static bool pineappleCakeGamePass { get; set; } = false;

    public static bool scallionPancakeGamePlayed { get; set; } = false;
    public static float scallionPancakeTotalTime { get; set; } = 0;
    public static bool scallionPancakeGamePass { get; set; } = false;
}

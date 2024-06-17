using UnityEngine;
using TMPro;

public class meatballsTimer : MonoBehaviour
{
    public TMP_Text timerText;

    void Start()
    {
        Timer timerInstance = Timer.Instance;
        timerInstance.currentGame = Timer.GameType.MeatBalls;
        timerInstance.UpdateTimerTextReference(timerText);
    }

    public void ResetTimer()
    {
        Timer.Instance.ResetTimer(); // 重置计时器
    }
}

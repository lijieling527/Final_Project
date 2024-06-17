using UnityEngine;
using TMPro;

public class pineapplecakeTimer : MonoBehaviour
{
    public TMP_Text timerText;

    void Start()
    {
        // 确保 Timer 的 timerText 被设置
        Timer timerInstance = Timer.Instance;
        timerInstance.currentGame = Timer.GameType.PineappleCake;
        timerInstance.UpdateTimerTextReference(timerText);
    }
    public void ResetTimer()
    {
        Timer.Instance.ResetTimer(); // 重置计时器
    }
}

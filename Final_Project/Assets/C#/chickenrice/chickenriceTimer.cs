using UnityEngine;
using TMPro;

public class chickenriceTimer : MonoBehaviour
{
    public TMP_Text timerText;

    void Start()
    {
        Timer timerInstance = Timer.Instance;
        timerInstance.currentGame = Timer.GameType.ChickenRice;
        timerInstance.UpdateTimerTextReference(timerText);
    }

    public void ResetTimer()
    {
        Timer.Instance.ResetTimer(); // 重置计时器
    }
}


using UnityEngine;
using TMPro;

public class Scallion_pancakeTimer : MonoBehaviour
{
    public TMP_Text timerText;

    void Start()
    {
        Timer timerInstance = Timer.Instance;
        timerInstance.currentGame = Timer.GameType.ScallionPancake;
        timerInstance.UpdateTimerTextReference(timerText);
    }
    public void ResetTimer()
    {
        Timer.Instance.ResetTimer(); // 重置计时器
    }
}

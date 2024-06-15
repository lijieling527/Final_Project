using UnityEngine;
using TMPro;

public class meatballsTimer : MonoBehaviour
{
    public TMP_Text timerText;

    void Start()
    {
        // 确保 Timer 的 timerText 被设置
        Timer timerInstance = Timer.Instance;
        timerInstance.UpdateTimerTextReference(timerText);
    }
}

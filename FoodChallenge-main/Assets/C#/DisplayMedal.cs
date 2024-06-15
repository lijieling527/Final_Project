using UnityEngine;

public class ShowMedal : MonoBehaviour
{
    public GameObject goldMedal; // 金牌图片
    public GameObject silverMedal; // 银牌图片
    public GameObject bronzeMedal; // 铜牌图片

    public static class TimerData
    {
        public static float TotalTime;
    }
    void Start()
    {
        DisplayMedal(TimerData.TotalTime);
    }
    
    private void DisplayMedal(float totalTime)
    {
        HideAllMedals();
        if (totalTime>0 && totalTime < 5)
        {
            goldMedal.SetActive(true);
        }
        else if (totalTime < 10)
        {
            silverMedal.SetActive(true);
        }
        else
        {
            bronzeMedal.SetActive(true);
        }
    }

    private void HideAllMedals()
    {
        goldMedal.SetActive(false);
        silverMedal.SetActive(false);
        bronzeMedal.SetActive(false);
    }
}

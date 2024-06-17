using UnityEngine;

public class ShowMedal : MonoBehaviour
{
    public GameObject chickenriceGoldMedal;
    public GameObject chickenriceSilverMedal;
    public GameObject chickenriceBronzeMedal;

    public GameObject meatBallsGoldMedal;
    public GameObject meatBallsSilverMedal;
    public GameObject meatBallsBronzeMedal;

    public GameObject pineappleCakeGoldMedal;
    public GameObject pineappleCakeSilverMedal;
    public GameObject pineappleCakeBronzeMedal;

    public GameObject scallionPancakeGoldMedal;
    public GameObject scallionPancakeSilverMedal;
    public GameObject scallionPancakeBronzeMedal;

    void Start()
    {
        DisplayMedals();
    }

    private void DisplayMedals()
    {
        // 显示鸡肉饭奖牌
        if (MedalManager.chickenriceGamePlayed && MedalManager.chickenriceGamePass)
        {
            ShowMedalForTime(chickenriceGoldMedal, chickenriceSilverMedal, chickenriceBronzeMedal, MedalManager.chickenriceTotalTime);
        }

        // 显示肉圆奖牌
        if (MedalManager.meatBallsGamePlayed && MedalManager.meatBallsGamePass)
        {
            ShowMedalForTime(meatBallsGoldMedal, meatBallsSilverMedal, meatBallsBronzeMedal, MedalManager.meatBallsTotalTime);
        }

        // 显示凤梨酥奖牌
        if (MedalManager.pineappleCakeGamePlayed && MedalManager.pineappleCakeGamePass)
        {
            ShowMedalForTime(pineappleCakeGoldMedal, pineappleCakeSilverMedal, pineappleCakeBronzeMedal, MedalManager.pineappleCakeTotalTime);
        }

        // 显示葱油饼奖牌
        if (MedalManager.scallionPancakeGamePlayed && MedalManager.scallionPancakeGamePass)
        {
            ShowMedalForTime(scallionPancakeGoldMedal, scallionPancakeSilverMedal, scallionPancakeBronzeMedal, MedalManager.scallionPancakeTotalTime);
        }
    }

    private void ShowMedalForTime(GameObject goldMedal, GameObject silverMedal, GameObject bronzeMedal, float totalTime)
    {
        goldMedal.SetActive(false);
        silverMedal.SetActive(false);
        bronzeMedal.SetActive(false);

        Debug.Log("Total Time: " + totalTime);
        // 根据时间显示对应的奖牌
        if (totalTime > 0 && totalTime < 50)
        {
            goldMedal.SetActive(true);
        }
        else if (totalTime >= 50 && totalTime < 110)
        {
            silverMedal.SetActive(true);
        }
        else if (totalTime >= 110)
        {
            bronzeMedal.SetActive(true);
        }
    }

}

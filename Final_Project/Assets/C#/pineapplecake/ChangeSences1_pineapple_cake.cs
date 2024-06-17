using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSences1_pineapple_cake : MonoBehaviour
{
    public string sceneToLoad;
    public Text collectedIngredientsText;
    public Text UncollectedIngredientsText;
    public GameObject GameObject;

    public Sprite questionMarkSprite;
    public Image[] ingredientSlots;
    public Sprite[] ingredientSprites;
    public List<string> objetfoods = new List<string> { "butter1", "butter2", "pineapple1", "pineapple2", "egg1", "egg2" };
    public Image Error;
    public GameObject PassObj;
    public GameObject FailObj;
    public GameObject RepeatObj;
    public GameObject ExtraObj;
    float waitingTime = 1f;
    float addTime = 10f;
    void Start()
    {
        // PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);
        HideHintImage();
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            ingredientSlots[i].sprite = questionMarkSprite;
        }
        // UpdateCollectedIngredients();
        //Error.gameObject.SetActive(false);

    }

    void UpdateCollectedIngredients()
    {
        List<string> ingredients = collectfood_pineapplecake.Instance.GetCollectedIngredients();
        // collectedIngredientsText.text = "收集到的食材:\n" + string.Join("\n", ingredients);
        List<string> Uningredients = collectfood_pineapplecake.Instance.GetUnCollectedIngredients();
        // UncollectedIngredientsText.text = "沒有收集到的食材:\n" + string.Join("\n", Uningredients);
        int size = ingredients.Count;
        // foreach (string ingredient in ingredients)
        List<string> newingredients;




        newingredients = DisplayCollectedIngredient(ingredients);
        collectfood_pineapplecake.Instance.OnIngredientsChanged(newingredients);
        // foreach (string ingredient in ingredients)
        int Count = GameObject.transform.childCount;

        foreach (Transform child in GameObject.transform)
        {
            // Debug.Log(123456789);
            Button ingredientButton = child.GetComponent<Button>();
            
            if (ingredientButton != null)
            {
                string ingredientName = child.name.Replace("1", "");
                string ingredientName2 = child.name.Replace("2", "");

                // Debug.Log(ingredientName);
                // Debug.Log(child.name);
                if (collectfood_pineapplecake.Instance.HasCollected(ingredientName) || collectfood_pineapplecake.Instance.HasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);
                    Count--;
                }

                if (collectfood_pineapplecake.Instance.NotHasCollected(ingredientName) || collectfood_pineapplecake.Instance.NotHasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);
                    Count--;
                }
            }
            
        }
        if (Count == 0 && !MedalManager.pineappleCakeGamePass)
        {
            Timer.Instance.StopTimer(); // 停止计时器
            FailObj.SetActive(true); // 显示失败提示
            Invoke("HideFailObj", waitingTime);
            CloseChoose();
        }
    }
    public List<string> DisplayCollectedIngredient(List<string> ingredients)
    {
        //for (int i = 0; i < ingredientSlots.Length; i++)
        //{
        //    if (ingredientSlots[i].sprite == questionMarkSprite)
        //    {
        //        ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
        //        break;
        //    }
        //}
        List<string> ingredientsToRemove = collectfood_pineapplecake.Instance.GetUnCollectedIngredients();

        foreach (string ingredient in ingredients)
        {
            if (!objetfoods.Contains(ingredient))
            {
                Debug.Log("NO");
                ingredientsToRemove.Add(ingredient);
                StartCoroutine(ShowAndHideErrorImage());

                ExtraObj.SetActive(true);
                Invoke("HideHintImage", waitingTime);
                Timer.Instance.AddTime(addTime);
            }
        }

        // Remove the collected ingredients
        foreach (string ingredient in ingredientsToRemove)
        {
            ingredients.Remove(ingredient);
        }
        collectfood_pineapplecake.Instance.OnUNIngredientsChanged(ingredientsToRemove);
        int i = 0;
        HashSet<string> uniqueIngredients = new HashSet<string>();

        foreach (string ingredient in ingredients)
        {
            string baseIngredient = ingredient.Replace("1", "").Replace("2", "");

            if (objetfoods.Contains(ingredient))
            {
                if (!uniqueIngredients.Contains(baseIngredient))
                {
                    uniqueIngredients.Add(baseIngredient);
                    ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
                    i++;
                }
                else if (uniqueIngredients.Contains(baseIngredient))
                {
                    RepeatObj.SetActive(true);
                    Invoke("HideHintImage", waitingTime);
                    Timer.Instance.AddTime(addTime);
                    ingredientsToRemove.Add(ingredient);
                }
            }

            if (uniqueIngredients.Count >= 3) // 確保集滿三個且不重複
            {
                PassObj.SetActive(true);
                Timer.Instance.StopTimer(); // 停止計時器
                Invoke("HideHintImage", waitingTime);
                
                Invoke("LoadNextScene", waitingTime);
                MedalManager.pineappleCakeGamePass = true;
                break; // 已經集滿三個，跳出循環
            }
        }
        return ingredients;
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("menu");
    }
    void HideHintImage()
    {
        PassObj.SetActive(false);
        FailObj.SetActive(false);
        RepeatObj.SetActive(false);
        ExtraObj.SetActive(false);
    }
    private IEnumerator ShowAndHideErrorImage()
    {
        // Show the image
        Error.gameObject.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide the image
        Error.gameObject.SetActive(false);
    }
    private Sprite GetIngredientSprite(string ingredient)
    {
        switch (ingredient)
        {
            case "butter1":
                return ingredientSprites[0];
            case "butter2":
                return ingredientSprites[1];
            case "egg1":
                return ingredientSprites[2];
            case "egg2":
                return ingredientSprites[3];
            case "flour1":
                return ingredientSprites[4];
            case "flour2":
                return ingredientSprites[5];
            case "pineapple1":
                return ingredientSprites[6];
            case "pineapple2":
                return ingredientSprites[7];
            case "green_onion1":
                return ingredientSprites[8];
            case "green_onion2":
                return ingredientSprites[9];
            default:
                return questionMarkSprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCollectedIngredients();
    }


    public void Choose蔥1()
    {
        SceneManager.LoadScene("蔥1");
    }
    public void Choose蔥2()
    {
        SceneManager.LoadScene("蔥2");
    }
    public void Choosebutter1()
    {
        SceneManager.LoadScene("butter1");
    }
    public void Choosebutter2()
    {
        SceneManager.LoadScene("butter2");
    }
    public void Choosepineapple1()
    {
        SceneManager.LoadScene("pineapple1");
    }
    public void Choosepineapple2()
    {
        SceneManager.LoadScene("pineapple2");
    }
    public void Chooseflour1()
    {
        SceneManager.LoadScene("flour1");
    }
    public void Chooseflour2()
    {
        SceneManager.LoadScene("flour2");
    }
    public void Chooseegg1()
    {
        SceneManager.LoadScene("egg1");
    }
    public void Chooseegg2()
    {
        SceneManager.LoadScene("egg2");
    }
    public void Choosegreen_onion1()
    {
        SceneManager.LoadScene("green_onion1");
    }
    public void Choosegreen_onion2()
    {
        SceneManager.LoadScene("green_onion2");
    }



    public void CloseChoose()
    {
        //string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        //SceneManager.LoadScene(returnScene);
        MedalManager.pineappleCakeGamePlayed = false;
        MedalManager.pineappleCakeTotalTime = 0;
        MedalManager.pineappleCakeGamePass = false;

        collectfood_pineapplecake.Instance.ResetCollectedIngredients();

        // Reset ingredient slots display
        ResetIngredientSlots();

        Invoke("LoadNextScene", waitingTime);
    }
    public void CloseQues()
    { 
        SceneManager.LoadScene("taiwan(pineapple_cake)");
    }
    public void RestartGame()
    {

        Debug.Log("restart");
        //string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        //SceneManager.LoadScene(returnScene);
        MedalManager.pineappleCakeGamePlayed = false;
        MedalManager.pineappleCakeTotalTime = 0;
        MedalManager.pineappleCakeGamePass = false;

        Timer.Instance.ResetTimer();
        collectfood_pineapplecake.Instance.ResetCollectedIngredients();

        // Reset ingredient slots display
        ResetIngredientSlots();
        SceneManager.LoadScene("taiwan(pineapple_cake)");
    }
    private void ResetIngredientSlots()
    {
        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            ingredientSlots[i].sprite = questionMarkSprite;
        }
    }


}
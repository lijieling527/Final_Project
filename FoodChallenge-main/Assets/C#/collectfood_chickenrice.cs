using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectfood_chickenrice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public static collectfood_chickenrice Instance { get; private set; }

    private List<string> collectedIngredients = new List<string>();
    private List<string> uncollectedIngredients = new List<string>();



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保證在切換場景時不銷毀該對象
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectIngredient(string ingredient)
    {
        if (!collectedIngredients.Contains(ingredient))
        {
            collectedIngredients.Add(ingredient);
            Debug.Log("Collected: " + ingredient);
            //CheckIngredients();
            // ChangeSences.DisplayCollectedIngredient(ingredient);
        }
        
    }

    public void UnCollectIngredient(string ingredient)
    {
        if (!uncollectedIngredients.Contains(ingredient))
        {
            uncollectedIngredients.Add(ingredient);
            Debug.Log("UnCollected: " + ingredient);
        }
    }
    
    public List<string> GetCollectedIngredients()
    {
        return new List<string>(collectedIngredients);
    }
    public List<string> GetUnCollectedIngredients()
    {
        return new List<string>(uncollectedIngredients);
    }
    public bool HasCollected(string ingredient)
    {
        return collectedIngredients.Contains(ingredient);
    }
    public bool NotHasCollected(string ingredient)
    {
        return uncollectedIngredients.Contains(ingredient);
    }
    public void OnIngredientsChanged(List<string> ingredient)
    {
        collectedIngredients = ingredient;
    }
    public void OnUNIngredientsChanged(List<string> ingredient)
    {
        uncollectedIngredients = ingredient;
    }
}
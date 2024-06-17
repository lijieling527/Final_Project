using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行
using UnityEngine.SceneManagement;

public class green_onion1 : MonoBehaviour
{
    private List<Question> questions;
    public Text questionText;
    public Text resultText;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Text TextA;
    public Text TextB;
    public Text TextC;
    public Text TextD;
    float waitingTime = 1f;

    private string currentIngredient;

    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>();

        // 加入問題
        questions.Add(new Question(
            "青蔥中哪種維生素含量較高？",
            new Dictionary<char, string>
            {
                {'A', "維生素A"},
                {'B', "維生素C"},
                {'C', "維生素D"},
                {'D', "維生素E"}
            },
            'B'));
        questionText.text = questions[0].Content;
        foreach (var option in questions[0].Options)
        {
            GameObject answerText = GameObject.Find("Text" + option.Key);
            answerText.GetComponentInChildren<Text>().text = option.Value;

        }

        buttonA.onClick.AddListener(MyButtonClickA);
        buttonB.onClick.AddListener(MyButtonClickB);
        buttonC.onClick.AddListener(MyButtonClickC);
        buttonD.onClick.AddListener(MyButtonClickD);

    }
    void MyButtonClickA()
    {
        CheckAnswer('A');
    }
    void MyButtonClickB()
    {
        CheckAnswer('B');
    }
    void MyButtonClickC()
    {
        CheckAnswer('C');
    }
    void MyButtonClickD()
    {
        CheckAnswer('D');
    }
    public Button buttonclose;
    void MyButtonClickclose()
    {
        // Debug.Log("123123123132132123561");
        UnityEngine.SceneManagement.SceneManager.LoadScene("taiwan(pineapple_cake)");
    }

    public void CheckAnswer(char selectedOption)
    {

        if (questions[0].CheckAnswer(selectedOption))
        {
            resultText.text = "答對了！";
            collectfood_pineapplecake.Instance.CollectIngredient("green_onion1");
            // ReturnToMainScene();
            // NextQuestion();

        }
        else
        {
            resultText.text = $"答錯了，再挑戰其他題吧";
            collectfood_pineapplecake.Instance.UnCollectIngredient("green_onion1");
            // collectfood.Instance.CollectIngredient(currentIngredient);
            // ReturnToMainScene();
        }
        Invoke("LoadNextScene", waitingTime);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("taiwan(pineapple_cake)");
    }
    // Update is called once per frame
    void ReturnToMainScene()
    {
        // 假設主場景名稱為 "MainScene"
        UnityEngine.SceneManagement.SceneManager.LoadScene("taiwan");
    }
    void Update()
    {

    }


    public class Question
    {
        public string Content { get; set; }
        public Dictionary<char, string> Options { get; set; }
        public char CorrectAnswer { get; set; }

        public Question(string content, Dictionary<char, string> options, char correctAnswer)
        {
            Content = content;
            Options = options;
            CorrectAnswer = correctAnswer;
        }

        public bool CheckAnswer(char selectedOption)
        {
            return char.ToUpper(selectedOption) == char.ToUpper(CorrectAnswer);
        }
    }
}
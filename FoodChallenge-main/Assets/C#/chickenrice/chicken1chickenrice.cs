using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行
using UnityEngine.SceneManagement;
public class chicken1chickenrice : MonoBehaviour
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
    float waitingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>();

        // 加入問題
        questions.Add(new Question(
            "雞肉中哪個部位脂肪含量最低？",
            new Dictionary<char, string>
            {
                {'A', "雞皮"},
                {'B', "雞翅"},
                {'C', "雞腿肉"},
                {'D', "雞胸肉"}
            },
            'D'));
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


    public void CheckAnswer(char selectedOption)
    {

        if (questions[0].CheckAnswer(selectedOption))
        {
            resultText.text = "答對了！";
            collectfood.Instance.CollectIngredient("chicken1");
            // NextQuestion();

        }
        else
        {
            resultText.text = $"答錯了，再挑戰其他題吧";
            collectfood.Instance.UnCollectIngredient("chicken1");
        }

        Invoke("LoadNextScene", waitingTime);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("taiwan(chickenrice)");
    }
    // Update is called once per frame

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
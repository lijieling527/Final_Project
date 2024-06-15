using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;    // 記得加這行


public class NewBehaviourScript : MonoBehaviour
{

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
    private List<Question> questions;
    private int currentQuestionIndex = 0;
    void Start()
    {
        
        // 初始化問題
        InitializeQuestions();

        // 顯示第一個問題
        ShowQuestion();

        buttonA.onClick.AddListener(MyButtonClickA);
        buttonB.onClick.AddListener(MyButtonClickB);
        buttonC.onClick.AddListener(MyButtonClickC);
        buttonD.onClick.AddListener(MyButtonClickD);


    }
    void InitializeQuestions()
    {
        questions = new List<Question>();

        // 加入問題
        questions.Add(new Question(
            "哪個季節是竹筍的主要生長期？",
            new Dictionary<char, string>
            {
                {'A', "春季"},
                {'B', "夏季"},
                {'C', "秋季"},
                {'D', "冬季"}
            },
            'A'));

        questions.Add(new Question(
            "竹筍是從竹子的哪個部分生長出來的？",
            new Dictionary<char, string>
            {
                {'A', "竹葉"},
                {'B', "竹節"},
                {'C', "地下根莖"},
                {'D', "竹幹"}
            },
            'C'));

        questions.Add(new Question(
            "下列何者非竹筍？",
            new Dictionary<char, string>
            {
                {'A', "綠竹筍"},
                {'B', "茭白筍"},
                {'C', "桂竹筍"},
                {'D', "箭筍"}
            },
            'B'));
    }
    void ShowQuestion()
    {
        // 顯示問題內容
        questionText.text = questions[currentQuestionIndex].Content;
        int index = 0;
        foreach (var option in questions[currentQuestionIndex].Options)
        {

            GameObject answerText = GameObject.Find("Text" + option.Key);
            answerText.GetComponentInChildren<Text>().text = option.Value;
            index++;
        }
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
    void Update()
    {
        

        //ResetButtons();
    }
  
    public void CheckAnswer(char selectedOption)
    {
        
        if (questions[currentQuestionIndex].CheckAnswer(selectedOption))
        {
            resultText.text = "答對了！";
            NextQuestion();

        }
        else
        {
            resultText.text = $"答錯了，正確答案是 {questions[currentQuestionIndex].Options[questions[currentQuestionIndex].CorrectAnswer]}";
        }
    }
    public void NextQuestion()
    {
        // 移至下一個問題
        currentQuestionIndex++;

        // 檢查是否已經回答完所有問題
        if (currentQuestionIndex < questions.Count)
        {
            // 顯示下一個問題
            resultText.text="~~請答題~~";
            ShowQuestion();

        }
        else
        {
            // 若已回答完所有問題，可以在這裡處理結束遊戲的邏輯
            Debug.Log("已回答完所有問題！");
        }
    }
    void ResetButtons()
    {

        buttonA.interactable = true; // 重置按鈕為可交互狀態（可被點擊）
        buttonA.onClick.RemoveAllListeners(); // 移除所有按鈕點擊事件監聽器
        buttonB.interactable = true; // 重置按鈕為可交互狀態（可被點擊）
        buttonB.onClick.RemoveAllListeners(); // 移除所有按鈕點擊事件監聽器
        buttonC.interactable = true; // 重置按鈕為可交互狀態（可被點擊）
        buttonC.onClick.RemoveAllListeners(); // 移除所有按鈕點擊事件監聽器
        buttonD.interactable = true; // 重置按鈕為可交互狀態（可被點擊）
        buttonD.onClick.RemoveAllListeners(); // 移除所有按鈕點擊事件監聽器


    }
    //void Update()
    //{
    //    //Press the space key to change the Text message
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        m_MyText.text = "My text has now changed.";
    //    }
    //}
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
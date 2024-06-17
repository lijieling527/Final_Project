using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null && (MedalManager.chickenriceGamePlayed || MedalManager.meatBallsGamePlayed || MedalManager.pineappleCakeGamePlayed || MedalManager.scallionPancakeGamePlayed))
        {
            timer.ResumeTimer();
        }
    }
}

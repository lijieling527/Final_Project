using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void ChangeToMenu()
    {
        SceneManager.LoadScene("menu");

        //SceneManager.LoadScene(1);
    }
    public void ChooseFood1()
    {
        SceneManager.LoadScene("蔥油餅");
    }
    public void ChooseFood2()
    {
        SceneManager.LoadScene("鳳梨酥");
    }
    public void ChooseFood3()
    {
        SceneManager.LoadScene("雞肉飯");
    }
    public void ChooseFood4()
    {
        SceneManager.LoadScene("肉圓");
    }
    public void CloseChoose()
    {
        SceneManager.LoadScene("map");

        //SceneManager.LoadScene(1);
    }
    public void meatballsQues()
    {
        SceneManager.LoadScene("Scenes/meatballs/taiwan(meatballs)");

    }
    public void pineappleCakeQues()
    {
        SceneManager.LoadScene("Scenes/pineapplecake/taiwan(pineapple_cake)");
    }
    public void chickenRiceQues()
    {
        SceneManager.LoadScene("Scenes/chickenrice/taiwan(chickenrice)");

    }
    public void scallionpancakeQues()
    {
        SceneManager.LoadScene("Scenes/Scallion_pancake/taiwan(Scallion_pancake)");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

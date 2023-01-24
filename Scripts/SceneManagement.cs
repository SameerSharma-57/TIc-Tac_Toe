using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void new_Game()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

    public void goToTutorial()
    {
        SceneManager.LoadScene(2);
    }
    
    
}

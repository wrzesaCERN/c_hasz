using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("GAME OVER");
    }

    public void Quit()
    {
        Debug.Log("Application qiut");
        Application.Quit();
    }

    public void Retry()
    {
        Debug.Log("Application retry");
        LevelControl.Lives = 4;
        LevelControl.NextLevel_kitchen();
    }

}


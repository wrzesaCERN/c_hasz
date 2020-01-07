using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    private static int _level =1;
    private static int _lives = 4;

    public static int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public static int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }
    // Start is called before the first frame update
    public static void NextLevel_bedroom()
    {
        SceneManager.LoadScene(3);
        _level = 3;
    }
    public static void NextLevel_kitchen()
    {
        SceneManager.LoadScene(0);
        _level = 1;

    }
    public static void NextLevel_livingroom()
    {
        SceneManager.LoadScene(2);
        _level = 2;
    }


}

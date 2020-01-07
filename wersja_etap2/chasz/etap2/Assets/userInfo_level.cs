using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfo_level : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
        livesText.text = "Level: " + LevelControl.Level.ToString();
    }
}

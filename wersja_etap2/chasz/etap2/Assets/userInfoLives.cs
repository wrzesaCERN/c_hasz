using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfoLives : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
        livesText.text = "Lives: " + (LevelControl.Lives / 2).ToString();
    }
}

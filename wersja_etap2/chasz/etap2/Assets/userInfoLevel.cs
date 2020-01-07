using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfoLevel : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
        livesText.text = "Level: " + CatScript.Level.ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfoDestruction : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
        livesText.text = "DESTRUCTION: " + CatScript.Things_destroyed.ToString() + "/" + CatScript.Things_all.ToString();
    }
}

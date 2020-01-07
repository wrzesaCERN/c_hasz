using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfo_description : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
        livesText.text = "Destruction: " + CatScript.Things_destroyed.ToString() + "/" + CatScript.Things_all.ToString();
    }
}

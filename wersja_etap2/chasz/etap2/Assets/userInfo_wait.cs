using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class userInfo_wait : MonoBehaviour
{
    private Text livesText;
    void Awake()
    {
        livesText = GetComponent<Text>();
    }
    void Update()
    {
      //  livesText.text = CatScript.Wait_caught.ToString();
    }
}

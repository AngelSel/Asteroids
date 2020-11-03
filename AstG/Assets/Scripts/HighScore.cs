using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScore : MonoBehaviour
{
    private Text _highScore;
    private void OnEnable()
    {
        _highScore = GetComponent<Text>();
        _highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}

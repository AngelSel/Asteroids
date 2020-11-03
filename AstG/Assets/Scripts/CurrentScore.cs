using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    private Text _currentScore;

    private void OnEnable()
    {
        _currentScore = GetComponent<Text>();
        _currentScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    Text currentScore;

    private void OnEnable()
    {
        currentScore = GetComponent<Text>();
        currentScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }
}

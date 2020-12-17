using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private const string HIGHSCORE_TEXT = "HighScore";
    private const string CURRENSCORE_TEXT = "CurrentScore";
  
    [SerializeField] private Text _scoreText;
    [SerializeField] private Button _replayButton;
  
    private int _score;
  
    private void Start()
    {
        _replayButton.onClick.AddListener(OnGameOver);
    }

    private void OnEnable()
    {
        ShipController.OnPlayerDied += OnPlayerDied;
        ShipController.OnPlayerScored += OnPlayerScored;
    }

    private void OnDisable()
    {
        ShipController.OnPlayerDied -= OnPlayerDied;
        ShipController.OnPlayerScored -= OnPlayerScored;
    }

    private void OnPlayerDied()
    {
        int _savedScore = PlayerPrefs.GetInt(HIGHSCORE_TEXT);
        if (_score > _savedScore)
            PlayerPrefs.SetInt(HIGHSCORE_TEXT, _score);
        PlayerPrefs.SetInt(CURRENSCORE_TEXT , _score);
    }
    private void OnPlayerScored()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    private void OnGameOver()
    {
        _scoreText.text = "0";
        _score = 0;
    }
  
}


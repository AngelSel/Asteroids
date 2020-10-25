using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public delegate void GameDelegate();
    public static event GameDelegate GameOver;    

    public static GameManager Instanse;

    public GameObject gameOverPage;
    public Text scoreText;

    enum PageState
    {
        None,
        GameOver
    }

    int score;
    bool isGameOver = false;

    public bool IsGameOver { get { return isGameOver; } }

    private void Awake()
    {
        Instanse = this;
        SetPageState(PageState.None);
    }
    private void Start()
    {
        score = 0;
    }

    private void OnEnable()
    {
        ShipController.OnPlayerDied += PlayerDied;
        ShipController.OnPlayerScored += PlayerScored;

    }
    private void OnDisable()
    {
        ShipController.OnPlayerDied -= PlayerDied;
        ShipController.OnPlayerScored -= PlayerScored;
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                gameOverPage.SetActive(false);
                break;

            case PageState.GameOver:
                gameOverPage.SetActive(true);
                break;

        }
    }

    public void ConfirmGameOver()
    {
        GameOver();
        scoreText.text = "0";
        score = 0;
        SetPageState(PageState.None);
        isGameOver = false;

    }

    void PlayerDied()
    {
        isGameOver = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore)
            PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("CurrentScore", score);


        SetPageState(PageState.GameOver);
    }

    void PlayerScored()
    {
        score++;
        scoreText.text = score.ToString();
    }

}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Button _replayButton;
    public delegate void GameDelegate();
    public static event GameDelegate GameOver;
    public static GameManager Instanse;

    public GameObject gameOverPage;


    enum PageState
    {
        None,
        GameOver
    }
    
    public bool isGameOver = false;

    public bool IsGameOver { get { return isGameOver; } }

    private void Awake()
    {
        Instanse = this;
        SetPageState(PageState.None);
    }
    private void Start()
    {
        _replayButton.onClick.AddListener(ConfirmGameOver);
    }

    private void OnEnable()
    {
        ShipController.OnPlayerDied += PlayerDied;
    }
    private void OnDisable()
    {
        ShipController.OnPlayerDied -= PlayerDied;
    }

    private void SetPageState(PageState state)
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
        SetPageState(PageState.None);
        isGameOver = false;

    }

    private void PlayerDied()
    {
        isGameOver = true;
        SetPageState(PageState.GameOver);
    }

}

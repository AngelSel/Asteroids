using UnityEngine;

public class BackgroundMovements : MonoBehaviour
{
    [SerializeField] private GameObject background;
    private void OnGameOverConfirmed()
    {
        background.transform.position = Vector3.zero;
    }

    private void OnEnable()
    {
        GameManager.GameOver += OnGameOverConfirmed;
    }
    private void OnDisable()
    {
        GameManager.GameOver -= OnGameOverConfirmed;
    }

    private void Update()
    {
        if (transform.position.y >= background.transform.position.y + 12.8f)
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y + 12.8f, 0);
    }


}

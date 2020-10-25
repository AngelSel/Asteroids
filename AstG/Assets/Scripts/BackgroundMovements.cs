using UnityEngine;

public class BackgroundMovements : MonoBehaviour
{
    public GameObject bc;
    void OnGameOverConf()
    {
        bc.transform.position = Vector3.zero;
    }

    private void OnEnable()
    {
        GameManager.GameOver += OnGameOverConf;
    }
    private void OnDisable()
    {
        GameManager.GameOver -= OnGameOverConf;
    }

    void Update()
    {
        if (transform.position.y >= bc.transform.position.y + 12.8f)
            bc.transform.position = new Vector3(bc.transform.position.x, bc.transform.position.y + 12.8f, 0);
    }


}

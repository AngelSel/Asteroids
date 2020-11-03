using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    private float heigth;
    private float widtgh;
    private bool isOn = false;
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;
    private Rigidbody2D rb;
    private GameManager game;
    public bool isWork;
    public TrailRenderer shipTrail;

    private void OnEnable()
    {
        GameManager.GameOver += OnGameOverComfirmed;
        Lean.Touch.LeanTouch.OnFingerDown += FingerDown;
        Lean.Touch.LeanTouch.OnFingerUp += FingerUp;
    }


    private void OnDisable()
    {
        GameManager.GameOver -= OnGameOverComfirmed;
        Lean.Touch.LeanTouch.OnFingerDown -= FingerDown;
        Lean.Touch.LeanTouch.OnFingerUp -= FingerUp;
    }

    private void OnGameOverComfirmed()
    {
        transform.position = new Vector3(0, -3, 0);
        rb.velocity = Vector3.zero;
        rb.simulated = true;
        shipTrail.Clear();
    }

    private void Start()
    {
        isWork = false;
        rb = GetComponent<Rigidbody2D>();
        Camera cam = Camera.main;
        heigth = 2f * cam.orthographicSize;
        widtgh = heigth * cam.aspect - 0.7f;
        game = GameManager.Instanse;
    }
    private void FingerDown(Lean.Touch.LeanFinger finger)
    {
        isOn = true;
    }

    private void FingerUp(Lean.Touch.LeanFinger finger)
    {
        isOn = false;
    }
    private void FixedUpdate()
    {
        if (game.IsGameOver)
            return;
        if (transform.position.x+0.2f >= widtgh / 2 || transform.position.x-0.2f <= (-widtgh / 2))
        {
            speed *= -1;
        }

        transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * speed));

        if (isOn)
        {
            rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Force);
            rb.drag = 0;
        }
        else
        {
            rb.drag = 2;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            rb.simulated = false;
            OnPlayerDied();
        }

        if(collision.gameObject.CompareTag("ScoreZone"))
        {
            OnPlayerScored();
        }

        if(collision.gameObject.CompareTag("Coin"))
        {
            OnPlayerScored();
            collision.gameObject.SetActive(false);
        }
    }
    
}

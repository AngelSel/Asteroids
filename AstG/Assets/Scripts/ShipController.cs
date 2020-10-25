using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    private float heigth;
    private float widtgh;
    bool isOn = false;
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;
    private float w;
    Rigidbody2D rb;
    GameManager game;
    public bool isWork;
    public TrailRenderer shipTrail;

    private void OnEnable()
    {
        GameManager.GameOver += OnGameOverComfirmed;
    }


    private void OnDisable()
    {
        GameManager.GameOver -= OnGameOverComfirmed;
    }

    void OnGameOverComfirmed()
    {
        transform.position = new Vector3(0, -3, 0);
        rb.velocity = Vector3.zero;
        rb.simulated = true;
        shipTrail.Clear();

    }

    void Start()
    {

        isWork = false;
        rb = GetComponent<Rigidbody2D>();
        Camera cam = Camera.main;
        heigth = 2f * cam.orthographicSize;
        widtgh = heigth * cam.aspect - 0.7f;
        w = widtgh;
        game = GameManager.Instanse;
    }

    private void Update()
    {

        /*   
   if(isWork)
   {
   isOn = true;
   }
   else
   {
   isOn = false;
           }    */

        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
   {
   isOn = true;
   }
   else
   {
   isOn = false;
   }

    }

    void FixedUpdate()
    {
        if (game.IsGameOver)
            return;
        if (transform.position.x+0.2f >= widtgh / 2 || transform.position.x-0.2f <= (-widtgh / 2))
        {
           speed = speed * -1;
            w = w * -1;

        }
         //pos = new Vector3(w / 2, transform.position.y);

        //transform.position = Vector3.Lerp(transform.position, pos, 1.2f * Time.deltaTime);


       transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);


        switch (isOn)
        {
            case true:
                rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Force);
                rb.drag = 0;
                break;
            case false:
                rb.drag = 2;
                break;

        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeathZone")
        {
            rb.simulated = false;
            OnPlayerDied();
        }

        if(collision.gameObject.tag == "ScoreZone")
        {
            OnPlayerScored();
        }

        if(collision.gameObject.tag == "Coin")
        {
            OnPlayerScored();
            collision.gameObject.SetActive(false);
        }
    }
    
}

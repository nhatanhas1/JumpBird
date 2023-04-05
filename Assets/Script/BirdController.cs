using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float force = 4;
    Rigidbody2D rb;
    public bool isJump;
    bool isClicked;

    Animator anim;

    public float flag = 0;
    int score = 0;

    [SerializeField]
    Text scoreText;


    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip pingClip, deadClip, flyClip;

    GameController gameController;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scoreText.text = "Score: " + score;

        gameController = FindObjectOfType<GameController>();
    }

    //Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //direction = GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    rb.velocity = Vector2.up * force;
        //    isJump = true;

        //}

        if (rb.velocity.y > 0)
        {
            float angle = Mathf.Lerp(0, 90, rb.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (rb.velocity.y == 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void FixedUpdate()
    {
        Jump();        
    }

    void Jump()
    {
        if (isJump)
        {
            rb.velocity = Vector2.up * force;
            isJump = false;
            if(source != null)
            {
                source.PlayOneShot(flyClip);
            }
        }
    }

    public void ButtonFlying()
    {
        if(flag == 0)
        {
            isJump = true;
            //Debug.Log("Click Button Flying");
        }
        else
        {
            Debug.Log("Bird are dead");
        }       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            flag = 1;
            anim.SetTrigger("Dead");
            source.PlayOneShot(deadClip);           
            Debug.Log("Dead Sound");
            gameController.ShowGameOverPanel(true);
            gameController.SetScoreText(score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MidPipe")
        {
            source.PlayOneShot(pingClip);
            Debug.Log("Ping Sound" + score);
            score++;
            scoreText.text = "Score: " + score;


        }
    }

}

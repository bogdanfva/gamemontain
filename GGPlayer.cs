using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGPlayer: MonoBehaviour
{
    public float speed = 7f;

    bool facingRight = true;

    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    int Life = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame 
    void Update()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move;
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.AddForce(new Vector2(0, 700f));
        }

        if ((move < 0) && facingRight)
            Flip();
        else if ((move > 0) && !facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D shit)
    {
        if (shit.gameObject.tag == "life")
        {
            Life++;
            Destroy(shit.gameObject);
        }
        if (shit.gameObject.tag == "Start")
        {
            SceneManager.LoadScene("Level1");
        }
        if (shit.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Level2");
        }
        if (shit.gameObject.tag == "Finish1")
        {
            SceneManager.LoadScene("Level3");
        }
        if (shit.gameObject.tag == "Finish2")
        {
            SceneManager.LoadScene("Theend");
        }
    }

    void OnCollisionEnter2D(Collision2D shit)
    {
        if (shit.gameObject.tag == "evil")
        {
            Invoke("ReloadLevel", 1);
            Life--;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Life = " + Life);
    }

    void ReloadLevel()
    {
        if (Life <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}

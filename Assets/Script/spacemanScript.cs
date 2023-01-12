using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spacemanScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    //what is difference between this and serialized field?
    public float flapSpeed;
    [SerializeField] int life, score;
    Animator anim;
    [SerializeField] GameObject sheild;
    bool isSheild;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)== true)
        {
            anim.SetBool("isWalk", true);
            myRigidbody.velocity = Vector2.up * flapSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            sheild.SetActive(true);
            isSheild = true;
        }
        else
        {
            sheild.SetActive(false);
            isSheild = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pipe")
        {
            //everytime the bird hits the pipe life will be decreased.
            life--;

            if (life == 0)
            {
                //used to reload the screen
                Invoke("restartGame", 2f);
                Debug.Log("i hit a pipe");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "points")
        {
            score++;
            Debug.Log("Gain points");
        }

        if(collision.tag == "groundCollision")
        {
            Invoke("restartGame", 2f);
        }
        
        if (collision.tag == "bullet" && isSheild == true)
        {
            Debug.Log("Sheild Activated");

            Destroy(collision.gameObject);
        }

        if (collision.tag == "bullet" && isSheild == false)
        {
            Debug.Log("Hit by bullet");
            life--;

            if (life == 0)
            {
                //used to reload the screen
                Invoke("restartGame", 2f);
                Debug.Log("i hit a pipe");
            }
        }

    }

    private void restartGame()
    {
        SceneManager.LoadScene(0);
    }

    public int lifeSetter()
    {
        return life;
    }

    public int scoreSetter()
    {
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float velocidade;
    private SpriteRenderer playerSprite;
    public bool flipx;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            velocidade = velocidade * -1;
            flipx = !flipx;
            playerSprite.flipX = flipx;
        }

        playerRb.velocity = new Vector2(velocidade, 0);
        
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Espinho")
        {
            SceneManager.LoadScene("gameover");
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Espinho")
        {
            GetComponent<Animator>().SetBool("Die", true);
            //SceneManager.LoadScene("gameover");
        }


    }

    public void GameOver()
    {
        SceneManager.LoadScene("gameover");
    }
}

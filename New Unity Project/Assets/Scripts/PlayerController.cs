using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    private AudioSource coinSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = "";
        setCountText();
        coinSound = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }



    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive (false);
            coinSound.Play();
            count = count + 1;
            setCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Reload();
            print("its working!");
        }
    }


    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16)
        {
            winText.text = "You Win!";
        }
    }

}
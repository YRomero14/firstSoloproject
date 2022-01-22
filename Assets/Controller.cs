using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public bool gameOver = false;
    public Text ScoreText;
    public int Score = 0;
    public Text Win;
    public float speed = 3.0f;
    public GameObject points;
    public AudioClip winClip;
    public Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        ScoreText.text = "Score:"+ Score.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rigidbody2d.MovePosition(rigidbody2d.transform.position + tempVect);
        }
        

          if (Score == 5)
                {
                    PlaySound(winClip);
                    Win.text = "You Win! By yusmari Romero.";

                    gameOver = true;
                    }

      if (Input.GetKey("escape"))
           {
         Application.Quit();
           }
    }
    
   public bool IsWinner() 
    {
        if (Score > 4) return true;
        return false;
    }
 
    public void ChangeScore (int scoreamount)
    { 
       Score = Score + scoreamount;
       ScoreText.text = "Score:" + Score.ToString();
       
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    


}
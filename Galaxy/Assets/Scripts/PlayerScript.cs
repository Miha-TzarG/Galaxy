using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 6f;
   
    public Rigidbody2D rb;
    public int HealthPlayer;
    public int Score;
    public Text textScore;
    public GameObject[] Lives;

    public GameObject panelGameOver;


    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;
    public Vector3 pos;

    public AudioSource audioSourceVzriv;
    public AudioClip shootClipVzriv;




    void Start()
    {
        float dist = Vector3.Distance(pos, Camera.main.transform.position);
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;

        Time.timeScale = 1;
        textScore.text = Score.ToString();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, leftBorder, rightBorder), Mathf.Clamp(pos.y, bottomBorder, topBorder), pos.z);

        var mousePosition = Input.mousePosition;
            //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
            var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок

       
    }

    public void FixedUpdate()
    {
        MovementLogic();

    }
    private void MovementLogic()
    {

    
        float moveHorizontal = Input.GetAxis("Horizontal");

           float moveVertical = Input.GetAxis("Vertical");

           Vector3 movement = new Vector3(moveHorizontal,  moveVertical , 0.0f);
       
           rb.AddForce(movement * Speed);
       
        
    }

    public void Damageplayer()
    {
       

        if(HealthPlayer - 1 == -2)
        {
            Lives[0].SetActive(false);
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
        }
        else
        {
            Lives[HealthPlayer].SetActive(false);
            HealthPlayer = HealthPlayer - 1;
           


        }
    }

    public void UpdateScore()
    {
        Score = Score + 10;
        textScore.text = Score.ToString();
        Playvzriv();
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene("Game");
    }

    public void Playvzriv()
    {
        audioSourceVzriv.PlayOneShot(shootClipVzriv);
    }
}

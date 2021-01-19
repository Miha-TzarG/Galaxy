using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinyEmemy : MonoBehaviour
{
    public float speedminiEmnemy;
    public Transform Player;
    public float dist;
    public Transform ParentPointShot;
    public string tagname;
    public PlayerScript playerScript;
   public GameObject mn;

    public Bullet bulletScript;

    void OnEnable()
    {
    
        if (this.tag == "NLO")
        {
    
            ParentPointShot = GameObject.FindGameObjectWithTag(tagname).GetComponent<Transform>();

    
        }
    }
    void Start()
    {
        Player = GameObject.Find("Player").transform;
     
    }

   
    void Update()
    {

        dist = Vector3.Distance(Player.position, transform.position);

        if (this.tag == "NLO")

        {
            if (dist < 12)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speedminiEmnemy * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * -speedminiEmnemy * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.right * speedminiEmnemy * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "NLO")
        {
            if (collision.tag == "LefBorder")
            {
                Debug.Log("dasd");
                gameObject.SetActive(false);
                gameObject.transform.parent = ParentPointShot;
                gameObject.transform.rotation = ParentPointShot.transform.rotation;
            }
            if (collision.tag == "Player")
            {
                
                playerScript = collision.gameObject.GetComponent<PlayerScript>();
                playerScript.Damageplayer();

                gameObject.SetActive(false);
                gameObject.transform.parent = ParentPointShot;
                gameObject.transform.rotation = ParentPointShot.transform.rotation;
            }
            if (collision.tag == "Bullet")
            {
                mn = GameObject.FindGameObjectWithTag("Player");
                playerScript = mn.GetComponent<PlayerScript>();
                playerScript.UpdateScore();
             

                bulletScript = collision.gameObject.GetComponent<Bullet>();
                collision.gameObject.SetActive(false);


                collision.gameObject.transform.parent = bulletScript.ParentPointShot;
                collision.gameObject.transform.rotation = bulletScript.ParentPointShot.transform.rotation;
               


                gameObject.SetActive(false);
                gameObject.transform.parent = ParentPointShot;
                gameObject.transform.rotation = ParentPointShot.transform.rotation;
            
            }
        }
        if (this.tag == "Rock2")
        {
            if (collision.tag == "Player")
            {
                playerScript = collision.gameObject.GetComponent<PlayerScript>();
                playerScript.Damageplayer();

                gameObject.SetActive(false);

            }
            if (collision.tag == "Bullet")
            {
                mn = GameObject.FindGameObjectWithTag("Player");
                playerScript = mn.GetComponent<PlayerScript>();
                playerScript.UpdateScore();
            
                bulletScript = collision.gameObject.GetComponent<Bullet>();
                collision.gameObject.SetActive(false);


                collision.gameObject.transform.parent = bulletScript.ParentPointShot;
                collision.gameObject.transform.rotation = bulletScript.ParentPointShot.transform.rotation;

                gameObject.SetActive(false);
                playerScript.UpdateScore();

            }

        }
    }
}

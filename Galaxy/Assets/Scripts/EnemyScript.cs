using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speedEnemy;

    public float TimeToDisable;
    public Transform ParentPointShot;
    public string tagname;


    public GameObject[] prefabMiniRock;

    public int KolvaminiRock;

    public GameObject prefabMini;
    public Transform parentMiniRock;

    public PlayerScript playerScript;
    public GameObject mn;

    public Bullet bulletScript;

    void OnEnable()
    {

        StartCoroutine(SetDisabled(TimeToDisable));


        ParentPointShot = GameObject.FindGameObjectWithTag(tagname).GetComponent<Transform>();

    }
    IEnumerator SetDisabled(float TimeToDisable)
    {

        yield return new WaitForSeconds(TimeToDisable);

        gameObject.SetActive(false);
        gameObject.transform.parent = ParentPointShot;
        gameObject.transform.rotation = ParentPointShot.transform.rotation;

    }




    void Update()
    {

        transform.Translate(Vector3.right * speedEnemy * Time.deltaTime);


    }

    public void CreateminiRock()
    {
        KolvaminiRock = Random.Range(0, 4);
        prefabMiniRock = new GameObject[KolvaminiRock];
        for (int i = 0; i < prefabMiniRock.Length; i++)

        {
            prefabMiniRock[i] = Instantiate(prefabMini, transform.position, transform.rotation, parentMiniRock);


            prefabMiniRock[i].SetActive(true);

            prefabMiniRock[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
            prefabMiniRock[i].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);


            prefabMiniRock[i].transform.parent = null;

            StartCoroutine(SetDisabledminiRock(TimeToDisable));
        }
    }
    IEnumerator SetDisabledminiRock(float TimeToDisable)
    {

        yield return new WaitForSeconds(TimeToDisable);
        gameObject.SetActive(false);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      
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
            CreateminiRock();

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
}

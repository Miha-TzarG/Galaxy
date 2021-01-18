using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet;

    public float TimeToDisable;
    public Transform ParentPointShot;

    public string tagname;
    void OnEnable()
    {
     
        StartCoroutine(SetDisabled(TimeToDisable));

        ParentPointShot = GameObject.FindGameObjectWithTag(tagname).GetComponent<Transform>();
        //this.transform.localScale = new Sc(1, 1, 1);
        transform.localScale.Set(1f, 1f, 1f);

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

        transform.Translate(Vector3.right * speedBullet * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NLO")
        {
            collision.gameObject.SetActive(false);
         
            gameObject.SetActive(false);
            Debug.Log("Check");
            //     gameObject.transform.parent = ParentPointShot;
            //  gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }

        if (collision.tag == "Rock1")
        {
       
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            //  gameObject.transform.parent = ParentPointShot;
            // gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }

        if (collision.tag == "Rock2")
        {

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            //  gameObject.transform.parent = ParentPointShot;
            // gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }
    }
}

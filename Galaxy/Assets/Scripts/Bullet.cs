using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBullet;

    public float TimeToDisable;
    public Transform ParentPointShot;

    public string tagname;
    public GameObject SpawnPoint;

    public EnemyScript enemyScript;
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

        transform.Translate(Vector3.right * speedBullet * Time.deltaTime);
    }
  
}

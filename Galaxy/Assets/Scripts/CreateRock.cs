using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRock : MonoBehaviour
{
    public Transform pool_parent;
    private int pool_element_ID = 0;

  

    public GameObject prefab;
    public int pool_count = 10;
    public GameObject[] pool_size;
    public EnemyScript en;

    public Transform point;

    public float TimeSpawn = 0.2f;
    private float nextTime = 0.0f;

    public Transform start;
    public Transform end;
    public float arriveTime = 3f;


  
    void Start()
    {
        
        pool_size = new GameObject[pool_count];
        for (int i = 0; i < pool_count; i++)
        {
            
            pool_size[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
            pool_size[i].SetActive(false);
          
            en.tagname = this.tag.ToString();
        }
        
       
    }

    void Update()
    {
        transform.position = Vector3.Lerp(start.position, end.position, Mathf.PingPong(Time.time / arriveTime, 1f));

        if (Time.time > nextTime)
        {
         
            nextTime = Time.time + TimeSpawn;
           
            GameObject obj = pool_parent.GetChild(pool_element_ID).gameObject;
                obj.SetActive(true);
                if (obj.activeInHierarchy)
                {
               
                obj.transform.position = new Vector3(point.transform.position.x, point.transform.position.y); 
                    obj.transform.parent = null;
                }


                pool_element_ID++;
                if (pool_element_ID > pool_parent.childCount - 1) pool_element_ID = 0;
            }

        
    }
}

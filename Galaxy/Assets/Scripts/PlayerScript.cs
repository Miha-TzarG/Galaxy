using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 6f;
   
    public Rigidbody2D rb;
    public bool a;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
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
}

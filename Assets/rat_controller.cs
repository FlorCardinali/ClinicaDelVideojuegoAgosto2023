using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rat_controller : MonoBehaviour
{
    //referencias
    private Rigidbody2D own_rb;
   

    //sistema de movimiento
    [SerializeField] float up_force = 2f;
    [SerializeField] float velocity = 2f;
    bool isLeft = false;
    bool isRight = false;
    private bool is_on_floor;

    private void Start()
    {   
        own_rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {

        //control del teclado
        if (Input.GetKeyDown(KeyCode.A))
        {
            clickLeft();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            realeaseLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            clickRight();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            realeaseRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonJump();
        }

    }   

    //Control de botones
    public void clickRight()
    {
        //clickeado
        isRight = true;
    }
    public void realeaseRight()
    {
        //soltado
        isRight = false;
    }
    public void clickLeft()
    {
        //clickeado
        isLeft = true;
    }
    public void realeaseLeft()
    {
        //soltado
        isLeft = false;
    }
    public void OnButtonJump() 
    {
        if (is_on_floor)
        {
            own_rb.AddForce(Vector2.up * up_force, ForceMode2D.Impulse);
            is_on_floor=false;
        }
        
    }

    private void FixedUpdate()
    {
        if (isLeft)
        {
            own_rb.AddForce(new Vector2(-velocity,0) * Time.deltaTime);
        }

        if (isRight)
        {
            own_rb.AddForce(new Vector2(velocity, 0) * Time.deltaTime);
        }
    }




    //deteccion del suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        //con el suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {   
        //deteccion del suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = false;
        }
    }
    

    //control de muerte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("muerte"))
        {
            //muerte del personaje
            own_rb.position = new Vector2(-7.5f,6f);
        }
    }
 

}//final

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class rat_controller : MonoBehaviour
{
    //referencias
    private Rigidbody2D own_rb;
   

    //sistema de movimiento
    [SerializeField] float up_force = 2f;
    [SerializeField] float velocity = 2f;
    private Vector2 new_position = Vector2.zero;
    private bool is_on_floor;


    // Start is called before the first frame update
    private void Start()
    {   
        own_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        own_rb.position += new_position;
    }   


    public void OnMovePlayer(InputValue value)
    {
        float dir = value.Get<float>();
        new_position.x = dir * velocity * Time.deltaTime; 
    }
    public void OnJump() 
    {
        if (is_on_floor)
        {
            own_rb.AddForce(Vector2.up * up_force, ForceMode2D.Impulse);
            is_on_floor=false;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //deteccion del suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("muerte"))
        {
            //muerte del personaje
            own_rb.position = new Vector2(-7.5f,6f);
            Debug.Log("ATRAVESANDO");

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



}

using System;
using UnityEngine;



public class Ox_Controller :  controller
{
    //referencias

    //sistema de movimiento

    private bool press_x;


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
        if (Input.GetKeyDown(KeyCode.X))
        {
            press_x = true;
        }
    }

    //Control de botones



    public void realeaseX()
    {
        //soltado
        press_x = false;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        //con el suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = true;
        }
        if (press_x && collision.collider.CompareTag("rock"))
        {
            Destroy(collision.collider.gameObject);
        }
    }

private void destroyRock(Collision2D collision)
    {
        
            
            Destroy(collision.collider.gameObject);
            }


    //control de muerte



}//final

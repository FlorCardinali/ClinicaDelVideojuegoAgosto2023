using System;
using UnityEngine;



public class Ox_Controller :  controller
{
    private bool press_x;

    //override de controller
    public override void Update()
    {
        base.Update();
        //control de X   
        if (Input.GetKeyDown(KeyCode.X))
        {
            press_x = true;
        }
    }
    public void realeaseX()
    {
        //soltado
        press_x = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (press_x && collision.collider.CompareTag("piedra"))
        {
            Destroy(collision.collider.gameObject);
        }
    }

    private void destroyRock(Collision2D collision)
    {
            Destroy(collision.collider.gameObject);
    }
  
}//final

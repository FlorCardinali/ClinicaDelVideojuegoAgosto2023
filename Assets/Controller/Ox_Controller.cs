using System;
using UnityEngine;



public class Ox_Controller :  controller
{
   

    protected void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("piedra"))

        {
            if(press_x)
            {

                Destroy(collision.collider.gameObject);
            }
            
        }
    }

    private void destroyRock(Collision2D collision)
    {
        animator.SetTrigger("Attack");
        Destroy(collision.collider.gameObject);
    }
  
}

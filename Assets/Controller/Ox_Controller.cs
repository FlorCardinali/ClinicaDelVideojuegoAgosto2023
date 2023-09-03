using System;
using UnityEngine;



public class Ox_Controller :  controller
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (press_x && collision.collider.CompareTag("piedra"))
        {
            Destroy(collision.collider.gameObject);
        }
    }

    private void destroyRock(Collision2D collision)
    {
            Destroy(collision.collider.gameObject);
    }
  
}

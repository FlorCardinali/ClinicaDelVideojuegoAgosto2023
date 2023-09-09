using System;
using UnityEngine;



public class Ox_Controller :  controller
{
    [SerializeField] string mainMenu = "Main menu";
   

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
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("muerte"))
        {
            //muerte del personaje
            own_rb.position = spawn;
            GameManager.instance.ResetScene(mainMenu);
        }
    }

}

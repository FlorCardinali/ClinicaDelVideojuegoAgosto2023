using UnityEngine;

public class jaula : MonoBehaviour
    
{
    [SerializeField] GameObject menuGanaste;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {           
            GameManager.instance.TocarJaula();
        }
        
    }
}


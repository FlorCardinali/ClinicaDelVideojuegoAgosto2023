using UnityEngine;

public class jaula : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool changeScene = GameManager.instance.TocarJaula();
            if (changeScene) {
                GameManager.instance.changeScene();
            }
           
        }

    }
}


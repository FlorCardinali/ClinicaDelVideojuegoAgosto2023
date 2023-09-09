using UnityEngine;

public class jaulaAlambre : MonoBehaviour

{
    [SerializeField] GameObject menuGanaste;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            menuGanaste.SetActive(true);
        }

    }
}
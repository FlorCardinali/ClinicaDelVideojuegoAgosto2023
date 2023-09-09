using UnityEngine;

public class movimientoFondo : MonoBehaviour
{
    [SerializeField] private Vector2 moveVelocity;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerRB;

    private void Awake()
    {
        
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        offset = (playerRB.velocity.x * 0.1f ) * moveVelocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    } 
}

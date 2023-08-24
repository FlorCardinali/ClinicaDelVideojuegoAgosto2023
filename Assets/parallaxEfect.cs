using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;

    private Transform camaraTransform;
    private Vector3 previousCameraPosition;
    private float spriteWidth, startPosition;
    void Start()
    {
        camaraTransform = Camera.main.transform;
        previousCameraPosition = camaraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = camaraTransform.position.x;
    }

    void LateUpdate()
    {
        float deltaX = (camaraTransform.position.x - previousCameraPosition.x) * parallaxMultiplier;
        float moveAmount = camaraTransform.position.x * (1 - parallaxMultiplier);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = camaraTransform.position;

        if (moveAmount > startPosition + spriteWidth){
            transform.Translate(new Vector3(spriteWidth,0,0));
            startPosition += spriteWidth;
        }else if (moveAmount < startPosition - spriteWidth){
            transform.Translate(new Vector3(-spriteWidth,0,0));
            startPosition -= spriteWidth;
        }
    }
}

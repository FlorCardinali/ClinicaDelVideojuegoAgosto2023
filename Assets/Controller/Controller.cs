using UnityEngine;


public class controller : MonoBehaviour
{
    //referencias
    protected Rigidbody2D own_rb;
   

    //sistema de movimiento
    [SerializeField] protected float up_force = 2f;
    [SerializeField] protected float velocity = 2f;
    bool isLeft = false;
    bool isRight = false;
    protected bool is_on_floor;
    protected Vector2 spawn;

    private void Start()
    {   
        own_rb = GetComponent<Rigidbody2D>();
        spawn = own_rb.position;
}
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

    }   

    //Control de botones
    public void clickRight()
    {
        //clickeado
        isRight = true;
    }
    public void realeaseRight()
    {
        //soltado
        isRight = false;
    }
    public void clickLeft()
    {
        //clickeado
        isLeft = true;
    }
    public void realeaseLeft()
    {
        //soltado
        isLeft = false;
    }
    public void OnButtonJump() 
    {
        if (is_on_floor)
        {
            own_rb.AddForce(Vector2.up * up_force, ForceMode2D.Impulse);
            is_on_floor=false;
        }
        
    }

    private void FixedUpdate()
    {
        if (isLeft)
        {
            //rotacion del personaje.
            transform.localScale = new Vector2(-1 , 1);
            own_rb.AddForce(new Vector2(-velocity,0) * Time.deltaTime);
        }

        if (isRight)
        {
            transform.localScale = new Vector2(1, 1);
            own_rb.AddForce(new Vector2(velocity, 0) * Time.deltaTime);
        }
    }




    //deteccion del suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        //con el suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {   
        //deteccion del suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = false;
        }
    }
    

    //control de muerte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("muerte"))
        {
            //muerte del personaje
            own_rb.position = spawn;
        }
    }
 

}//final
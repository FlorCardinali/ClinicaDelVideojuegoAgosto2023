using UnityEngine;


public class controller : MonoBehaviour
{
    //referencias
    protected Rigidbody2D own_rb;
    public Animator animator;
    [SerializeField] string sceneName;

    //sistema de movimiento
    [SerializeField] protected float up_force = 2f;
    [SerializeField] protected float velocity = 2f;
    bool isLeft = false;
    bool isRight = false;
    protected bool press_x = false;
    protected bool is_on_floor;
    public Vector2 spawn;

    protected void Start()
    {   
        own_rb = GetComponent<Rigidbody2D>();
        spawn = own_rb.position;
    }
    public void Update()
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            press_x = true;
        }
        else if ( Input.GetKeyUp(KeyCode.X))
        {
            press_x = false;
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
            animator.SetBool("IsJumping", true);
            own_rb.AddForce(Vector2.up * up_force, ForceMode2D.Impulse);
            is_on_floor=false;
        }   
    }
    public void realeaseX()
    {
        //soltado
        press_x = false;
    }

    protected void FixedUpdate()
    {
        if (isLeft)
        {
            //rotacion del personaje.
            transform.localScale = new Vector2(-1 , 1);
            own_rb.AddForce(new Vector2(-velocity,0) * Time.deltaTime);
            animator.SetFloat("Speed", velocity* Time.deltaTime);
        }

        if (isRight)
        {
            transform.localScale = new Vector2(1, 1);
            own_rb.AddForce(new Vector2(velocity, 0) * Time.deltaTime);
            animator.SetFloat("Speed", velocity* Time.deltaTime);
        }

        if(!isLeft && !isRight){
            animator.SetFloat("Speed", 0);
        }
    }




    //deteccion del suelo
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {    
        //con el suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = true;
            animator.SetBool("IsJumping", false);
        }
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {   
        //deteccion del suelo
        if (collision.collider.CompareTag("grass"))
        {
            is_on_floor = false;
        }
    }
    

    //control de muerte
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("muerte"))
        {
            //muerte del personaje
            own_rb.position = spawn;
            GameManager.instance.ResetScene(sceneName);
        }
    }
 
}//final

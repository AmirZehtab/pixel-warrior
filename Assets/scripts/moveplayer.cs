using UnityEngine;

public class moveplayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;
    private SpriteRenderer sr;
    private bool lastmove ;
    private bool isG;
    public Transform gcheck;
    public LayerMask layercheck;
    public bool canMove = true;
   int temp = 0;
    public AudioSource rsfx;
    
        
    

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); 
        Time.timeScale = 1;
         }

     void Update(){

        if (!canMove){moveInput = Vector2.zero; anim.SetTrigger("Idle");
        transform.eulerAngles = new Vector3(0f , -180f , 0f);
        rsfx.Stop();
        return;} 

        moveInput.x= 
        Input.GetAxisRaw("Horizontal");
         
        if(moveInput.x > 0 && !lastmove){
            
            transform.eulerAngles = new Vector3(0f , -180f , 0f);
            lastmove = !lastmove;
           

        }else if(moveInput.x < 0 && lastmove){
            
            transform.eulerAngles = new Vector3(0f , 0f , 0f);
            lastmove = !lastmove; 
        }
        if(rb.linearVelocity.x > 0){psc(true); }
        if(rb.linearVelocity.x < 0){psc(true); }
        
        if(moveInput.x == 0){
            rsfx.Stop();
            temp = 0;
        }
        

        isG = Physics2D.OverlapCapsule(gcheck.position,new Vector2(0.8f,0.5f) ,
        CapsuleDirection2D.Horizontal,0,layercheck);

        if(Input.GetKeyDown(KeyCode.W) && isG){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("Jump");
            
        }

       

        anim.SetFloat("speed",Mathf.Abs(moveInput.magnitude));
    }
    
    void psc(bool _bool){
        if(temp == 1)return;

        if(_bool){
            rsfx.Play();
            temp = 1;
        }
    }
    void FixedUpdate(){
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

    }

    
    
};

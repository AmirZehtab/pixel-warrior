using UnityEngine;

public class enemimove : MonoBehaviour
{
    public float speed;
    public Transform playerpos;
    private Rigidbody2D rb;
    private Animator anime;
    private SpriteRenderer er;
    public AudioSource rsfx;
    
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        playerpos = GameObject.FindWithTag("Player").transform;
        anime = GetComponent<Animator>();
        er = GetComponent<SpriteRenderer>();
        rsfx.Play();
    }

    void Update(){
        speed = options.Enemyspeed;
        transform.position = Vector2.MoveTowards(transform.position , playerpos.position , speed * Time.deltaTime);

        Vector2 direction = (playerpos.position - transform.position);

        

        
        anime.SetTrigger("Run");
        
        


        if(direction.x < 0){
         transform.eulerAngles = new Vector3(0f , 0f , 0f);
            
        }else if(direction.x > 0){
            transform.eulerAngles = new Vector3(0f , -180f , 0f);
            
        }
    }




    
    
}

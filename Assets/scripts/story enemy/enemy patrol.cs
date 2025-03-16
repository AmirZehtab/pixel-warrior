using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseSpeed = 4f;
    public float chaseRange = 5f;
    private Transform player;
    private Vector3 initialPosition;
    private EnemyState currentState = EnemyState.Idle;
    bool b;
    private Animator anim; 
    private Vector2 direction;
    public AudioSource sfx;
    bool c = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        anim.SetFloat("speed",0);
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                CheckForPlayer();
                if(!c){sfx.Stop();c = true;}
                break;

            case EnemyState.Chase:
                ChasePlayer();
                CheckIfPlayerEscaped();
                if(c){sfx.Play();c = false;}
                
                break;
        }

         if(direction.x < 0){
         transform.eulerAngles = new Vector3(0f , 0f , 0f);
            
        }else if(direction.x > 0){
            transform.eulerAngles = new Vector3(0f , -180f , 0f);
            
        }

        if(b){
            direction = (initialPosition - transform.position);
            transform.position = Vector2.MoveTowards(transform.position,initialPosition, chaseSpeed * Time.deltaTime);
            currentState = EnemyState.Idle;
            if(transform.position == initialPosition){
                b = false;
                anim.SetFloat("speed",0);
            }
        }
    }

    void CheckForPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < chaseRange)
        {
            currentState = EnemyState.Chase;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        direction = (player.position - transform.position);
        anim.SetFloat("speed",1);

        
    }

    bool CheckIfPlayerEscaped()
    {
        if (Vector2.Distance(transform.position, player.position) > chaseRange + 2) 
        {
           
             
            b = true;
            
        }
        return b;
    }
}
public enum EnemyState
{
    Idle,  
    Chase  
}

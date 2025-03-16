using System.Collections;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    public int damage = 20;
    public float range = 1f;
    public Transform hitrange;
    public LayerMask enemylayer;
    public float cooldown = 1f;          
    private float cooldowntime = 0f; 
    private Animator anim;
    public Collider2D[] hitenem;
    public AudioClip attacksfx;
    public AudioSource sfx;
    public AudioClip hits;
    
    
    

    void Start(){
        hitrange = GetComponent<Transform>();
        anim = transform.parent.GetComponent<Animator>();
        
    }

    void Update(){
        cooldowntime += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)){
           if (cooldowntime >= cooldown){
             StartCoroutine(attack());
            anim.SetTrigger("Attack");
             cooldowntime = 0;
            
           }
           

            
        }
        
        
 }
         
    

    IEnumerator attack(){
    yield return new 
    WaitForSeconds(0.4f);

        hitenem = Physics2D.OverlapCircleAll(hitrange.position, range, enemylayer);
        sfx.PlayOneShot(attacksfx);
        foreach (Collider2D enemy in hitenem)
        {
            
            enemy.GetComponentInChildren<playerdamage>().cooldowntime = 0;
            enemy.GetComponent<enemyhealth>().Takedamage(damage, true);
            sfx.PlayOneShot(hits);

            
            
                
            
        }
    }
}

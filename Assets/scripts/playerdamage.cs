using UnityEngine;
using System.Collections;


public class playerdamage : MonoBehaviour
{
    public int damage = 20;
    public LayerMask layer;               
    public Transform box;                 
    public float cooldown = 1f;          
    public float cooldowntime;     
    private Animator anim;
    public AudioClip attacksfx;
    public AudioSource sfxs;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        box = GetComponent<Transform>();
       
    }

    void Update()
    {
        cooldowntime += Time.deltaTime;

        if (isplayer())
        {
            if (cooldowntime >= cooldown)
            {
                StartCoroutine(attack());
                anim.SetTrigger("Attack");
               
            }
        }
    }

    public bool isplayer()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(box.position, new Vector2(0.5f, 0.5f), 0f, Vector2.left, 0.8f, layer);

        

        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    IEnumerator attack()
    {
       
        yield return new WaitForSeconds(0.5f);
        if(cooldowntime >= cooldown){
        sfxs.Play();
        RaycastHit2D hit = Physics2D.BoxCast(box.position, new Vector2(1f, 1f), 0f, Vector2.left, 1f, layer);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            
            hit.collider.GetComponent<playerhealth>().Damagepl(damage,true);
             
        }cooldowntime = 0f;}
    }
}
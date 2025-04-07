using System.Collections;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    public int damage;
    public float range = 1f;
    public Transform hitrange;
    public LayerMask enemylayer;
    public float cooldown;          
    private float cooldowntime; 
    private Animator anim;
    public Collider2D[] hitenem;
    public AudioClip swordsound;
    public AudioClip macesound;
    public AudioSource sfx;
    public AudioClip hits;
    public bool w = true;
    
    
    

    void Start(){
        hitrange = GetComponent<Transform>();
        anim = transform.parent.GetComponent<Animator>();
        
    }

    void Update()
    {       
        cooldowntime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cooldowntime >= cooldown)
            {
                StartCoroutine(attack());
                anim.SetTrigger("Attack");
                cooldowntime = 0;

            }
        }
    }


        IEnumerator attack()
        {
            yield return new
            WaitForSeconds(0.4f);
            if (w)
            {
                sfx.PlayOneShot(macesound);
            }
            else
            {
                sfx.PlayOneShot(swordsound);
            }

            hitenem = Physics2D.OverlapCircleAll(hitrange.position, range + 0.5f, enemylayer);


            foreach (Collider2D enemy in hitenem)
            {

                //enemy.GetComponentInChildren<playerdamage>().cooldownTimer = 0;
                enemy.GetComponent<enemyhealth>().Takedamage(damage, true);
                sfx.PlayOneShot(hits);





            }
        }
    
}

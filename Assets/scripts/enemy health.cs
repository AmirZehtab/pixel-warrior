using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour
{
    public int health;
    public int maxhealth = 100;
    private Animator anim;
    public GameObject Hill;
   

    // public Transform pos;
    // public GameObject it;


    void Start(){
        health = maxhealth;
        anim = GetComponent<Animator>();
        
    }

    public void Takedamage(int amount , bool a){
        health = health - amount;
        if(a == true){
            anim.SetTrigger("Hurt");
            a = false;
        }
    }
    //  Transform pos ;
    void Update(){
        if(health <= 0){
           
            StartCoroutine(Delay());
            anim.SetTrigger("Death");
        }
         
    }
    
    IEnumerator Delay(){
        yield return new
        WaitForSeconds(0.5f);
        // Vector2 pos = transform.position;
        int rnd = Random.Range(0,7);
        if(rnd == 3){
            Instantiate(Hill,transform.position,Quaternion.identity);
        }
        
        print(transform.position);
        Destroy(gameObject);
    }

}
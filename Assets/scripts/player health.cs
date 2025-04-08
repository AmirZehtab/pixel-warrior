using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerhealth : MonoBehaviour
{
    public int health;
    private int maxhealth = 100;
    private Animator anim;
    public int score;
    public healthbar healthbar;
    bool d = false;
    float cooldown; 
    public AudioClip damagesfx;
    public AudioSource sfx;
    

     void Start(){
        health = maxhealth;
        anim = GetComponent<Animator>();
        healthbar.setmax(maxhealth);
        
        
    }

    void Update(){
        cooldown += Time.deltaTime ;
        if(health <= 0){
            anim.SetTrigger("Death");

            die();
        }
        if(cooldown > 1){
        if(Input.GetKeyDown(KeyCode.S) ){
            d = true;
            anim.SetTrigger("block");
            cooldown = 0;
        }}

         

        if(d == true){
            StartCoroutine(def());
        }
    }
    public void gethealth(int hill){
        if(health <= 80){
        health += hill;
        }else{
            health = maxhealth;
        }
        healthbar.sethp(health);
    }
    public void Damagepl(int amount,bool a){
        if(!d){
        health = health - amount;
        healthbar.sethp(health);
            anim.SetTrigger("hurt");
            sfx.PlayOneShot(damagesfx);
        if(a == true){
            
            a = false;
        }}
        
    }

    void die(){
        
        StartCoroutine(lose());
        
    }


    IEnumerator def(){
        yield return new WaitForSeconds(0.3f);
         d = false; 
    }
    IEnumerator lose()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("menu");
    }

    
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerStateSwitcher : MonoBehaviour
{
    public Sprite normalSprite;           
    public Sprite armoredSprite;          
    public RuntimeAnimatorController normalController;  
    public RuntimeAnimatorController armoredController;  
    private SpriteRenderer spriteRenderer;  
    private Animator animator;             
    private bool isArmored = false;   
    public Enemydamage _enemydamage;
    public Image sword;
    public Image mace;
    public AudioClip Changeweopon;
    public AudioSource sfx;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sword.enabled = false;

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isArmored = !isArmored;
            sfx.PlayOneShot(Changeweopon);

            
            spriteRenderer.sprite = isArmored ? armoredSprite : normalSprite;

            if(isArmored){
                _enemydamage.damage = 30;
                _enemydamage.cooldown = 1.3f;
                _enemydamage.w = false;
                sword.enabled = true;
                mace.enabled = false;

            }
            else if(!isArmored){
                _enemydamage.damage = 20;
                _enemydamage.cooldown = 0.9f;
                _enemydamage.w = true;
                sword.enabled = false;
                mace.enabled = true;
            }

            
            animator.runtimeAnimatorController = isArmored ? armoredController : normalController;
        }
    }
}

using UnityEngine;

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
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isArmored = !isArmored;

            
            spriteRenderer.sprite = isArmored ? armoredSprite : normalSprite;

            if(isArmored){
                _enemydamage.damage = 30;
                _enemydamage.cooldown = 1.3f;
                _enemydamage.w = false;
            }else if(!isArmored){
                _enemydamage.damage = 20;
                _enemydamage.cooldown = 0.9f;
                _enemydamage.w = true;
            }

            
            animator.runtimeAnimatorController = isArmored ? armoredController : normalController;
        }
    }
}

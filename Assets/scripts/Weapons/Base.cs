using UnityEngine;

public class Base : MonoBehaviour
{
    public Sprite normalSprite;           
        public Sprite armoredSprite;          
    public RuntimeAnimatorController normalController;  
    public RuntimeAnimatorController armoredController;  

    private SpriteRenderer spriteRenderer;  
    private Animator animator;             
    private bool isArmored = false;        
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

            
            animator.runtimeAnimatorController = isArmored ? armoredController : normalController;
        }
    }
}

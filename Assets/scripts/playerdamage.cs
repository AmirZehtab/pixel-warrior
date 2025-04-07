using UnityEngine;
using System.Collections;

public class playerdamage : MonoBehaviour
{
    public int damage = 20;
    public LayerMask layer;
    public Transform box;
    public float cooldown = 3f;
    public float cooldownTimer = 0f;

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
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            // فقط اگر پلیر هنوز داخل محدوده هست، حمله کن
            RaycastHit2D hit = Physics2D.BoxCast(box.position, new Vector2(1f, 1f), 0f, Vector2.left, 0.5f, layer);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                anim.SetTrigger("Attack");
                StartCoroutine(Attack(hit.collider.gameObject)); // دشمن دقیقاً به اون آبجکت پلیر حمله می‌کنه
                cooldownTimer = cooldown; // فوراً ریست کن
            }
        }
    }

    IEnumerator Attack(GameObject player)
    {
        yield return new WaitForSeconds(0.5f); // برای هماهنگی با انیمیشن
        RaycastHit2D hit = Physics2D.BoxCast(box.position, new Vector2(1f, 1f), 0f, Vector2.left, 0.5f, layer);
        sfxs.Play();

        if (player != null && hit.collider != null && hit.collider.CompareTag("Player"))
        {
            player.GetComponent<playerhealth>()?.Damagepl(damage, true);
        }
    }
}

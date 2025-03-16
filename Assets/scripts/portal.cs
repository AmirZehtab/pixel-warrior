using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextSceneName;
    public Sprite portalOn;
    public Sprite portalOff;
    private SpriteRenderer spriteRenderer;
    private bool isPortalActive = false;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = portalOff;
    }

    void Update()
    {
        if (!isPortalActive && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            ActivatePortal();
        }
    }

    void ActivatePortal()
    {
        isPortalActive = true;
        spriteRenderer.sprite = portalOn;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPortalActive && other.CompareTag("Player"))
        {
            FindObjectOfType<timer>().CompleteLevel();
            SceneManager.LoadScene(nextSceneName);
            
        }
    }
}

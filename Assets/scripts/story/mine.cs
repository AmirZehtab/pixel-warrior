using UnityEngine;

public class mine : MonoBehaviour
{
    public Dialogue dialogue; 
    private bool played = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !played)
        {
            played = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}

using UnityEngine;

public class heart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<playerhealth>().gethealth(20);
            Destroy(gameObject);
        }
    }
}

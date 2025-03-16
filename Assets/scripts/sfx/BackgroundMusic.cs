using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMusicManager : MonoBehaviour
{
    public AudioSource bm;
    void Awake()
    {
        
        if (SceneManager.GetActiveScene().name != "menu")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
       
        if (SceneManager.GetActiveScene().name == "menu")
        {
            bm.Stop();
        }
    }
}
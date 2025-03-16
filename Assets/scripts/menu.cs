using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class menu : MonoBehaviour
{
    public GameObject menuPanel;

    
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause();
        }
    }


    void pause(){

         menuPanel.SetActive(true);
         Time.timeScale = 0;
    }

    public void PlayGame()
    {
        menuPanel.SetActive(false); 
        Time.timeScale = 1; 
    }

    public void QuitGame(){
       SceneManager.LoadScene("menu");
    }
}

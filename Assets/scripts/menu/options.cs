using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class options : MonoBehaviour
{
        public static float Enemyspeed;
        public Slider Espeed;
        public TMP_Text bwave;


        void Start(){

        Enemyspeed = PlayerPrefs.GetFloat("EnemySpeed", 2.0f);
        Espeed.value = Enemyspeed;
        Espeed.onValueChanged.AddListener(UpdateEnemySpeed);
        int topw = PlayerPrefs.GetInt("TopWave", 0);

       bwave.text= "TOP WAVE: " + topw;
    }


    private void UpdateEnemySpeed(float newe){
            
        Enemyspeed = newe ;
        PlayerPrefs.SetFloat("EnemySpeed", Enemyspeed);
        PlayerPrefs.Save();
    }

    public void Survival(){
        SceneManager.LoadScene("survival");
    }

    public void Story(){
        SceneManager.LoadScene("levelchoose");
    }

    public void exit(){
        Application.Quit();
    }

}

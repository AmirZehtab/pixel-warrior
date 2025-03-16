// using UnityEngine;
// using UnityEngine.UI;

// public class setting : MonoBehaviour
// {
//     public GameObject Setting;
//     public Slider Espeed;
//     public static float Enemyspeed = 3f;

//     void Start(){
//         Espeed.value = Enemyspeed;
//         Espeed.onValueChanged.AddListener(UpdateEnemySpeed);
//     }


//     private void UpdateEnemySpeed(float newe){
            
//         Enemyspeed = newe;
//     }

//     public void OpenSettings(){
//         Setting.SetActive(true);
//         Time.timeScale = 0;
//     }

//     public void CloseSetings(){
//         Setting.SetActive(false);
//         Time.timeScale = 1;
//     }
// }

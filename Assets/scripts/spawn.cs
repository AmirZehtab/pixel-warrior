using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawners;
    private int count = 3;
    private int wavenumber = 0;
    private bool hea = false;
    public TMP_Text waveText;
    

    void Start(){
        // StartCoroutine(spawnwave());
    }

    void Update(){
        if(Time.timeScale == 0) return;
            
        
        Enemy[] enemies = FindObjectsOfType<Enemy>(); 
        if(enemies.Length == 0 && hea == false){
            hea = true;
            StartCoroutine(spawnwave());
            }
        }
        
    
    void spawnenemy(){
        int rnd = Random.Range(0,spawners.Length);

        Transform point = spawners[rnd];
        Instantiate(enemy,point.position,Quaternion.identity);
        }

        IEnumerator spawnwave(){
            wavenumber++;
            waveText.text = "Wave: " + wavenumber;
            for(int i = 0; i < count; i++){
                spawnenemy();
                yield return new WaitForSeconds(1);
            }
            
            
             Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemyhealth in enemies){
            enemyhealth.GetComponent<enemyhealth>().maxhealth += 10;
        }
            if(wavenumber % 6 == 0){
                count++;
            }
            // enemyhealth enemyhealth = enemy.GetComponent<enemyhealth>();
            // enemyhealth.maxhealth += 10;
            waveupdater();
            hea = false;
           
        }

        void waveupdater(){
            int topw = PlayerPrefs.GetInt("TopWave", 0);

            if(wavenumber > topw){
                PlayerPrefs.SetInt("TopWave", wavenumber);
                PlayerPrefs.Save();
            }

        }


}

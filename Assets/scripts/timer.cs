using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timer : MonoBehaviour
{
    private float levelTime = 0f;
    private bool isLevelRunning;
    public TMP_Text showtime;

    void Start()
    {
        levelTime = 0f;
        isLevelRunning = true;
    }

    void Update()
    {
        if (isLevelRunning)
        {
            levelTime += Time.deltaTime; 
            showtime.text = levelTime.ToString("F2");
        }
    }

    public void CompleteLevel()
    {
        isLevelRunning = false;
        string levelKey = "LevelTime_" + SceneManager.GetActiveScene().name;
        PlayerPrefs.SetFloat(levelKey, levelTime);
        PlayerPrefs.Save();
    }
}

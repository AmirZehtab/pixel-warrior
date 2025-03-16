using UnityEngine;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    public TMP_Text[] levelTimeTexts;
    public string[] levelNames;
    void Start()
    {
        for (int i = 0; i < levelNames.Length; i++)
        {
            string levelKey = "LevelTime_" + levelNames[i];
            float time = PlayerPrefs.GetFloat(levelKey, 0);

            if (time > 0)
            {
                levelTimeTexts[i].text = "Best Time: " + time.ToString("F2") + "s"; 
            }
            else
            {
                levelTimeTexts[i].text = "Not Completed";
            }
        }
    }

    
}

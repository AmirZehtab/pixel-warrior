using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;


    public void setmax(int hp){
        slider.maxValue = hp;
        slider.value= hp;
    }

    public void sethp(int hp){
        slider.value = hp;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; 


public class choose : MonoBehaviour
{
    public void level0(){
        SceneManager.LoadScene("level0");
    }

    public void level1(){
        SceneManager.LoadScene("level1");
    }

    public void level2(){
        SceneManager.LoadScene("level2");
    }

    public void level3(){
        SceneManager.LoadScene("level3");
    }

    public void level4(){
        SceneManager.LoadScene("level4");
    }

    public void level5(){
        SceneManager.LoadScene("level5");
    }

    public void back(){
        SceneManager.LoadScene("menu");
    }
}

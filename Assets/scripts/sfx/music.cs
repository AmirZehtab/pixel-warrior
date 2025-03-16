using UnityEngine;
using UnityEngine.EventSystems;


public class music : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] AudioSource menus;
    [SerializeField] AudioSource sfx;

    public AudioClip background;
    public AudioClip button;
    public AudioClip hovers;


    void Start(){
        menus.clip = background;
        menus.Play();
    }



    public void buttons(){
        sfx.clip = button; 
        sfx.Play();
    }

    public void OnPointerEnter(PointerEventData eventData){
        // if (sfx != null && hovers != null)
        // {
        //     sfx.PlayOneShot(hovers);
        // }
        // sfx.clip = hovers;
        sfx.PlayOneShot(hovers);
    }
    

}

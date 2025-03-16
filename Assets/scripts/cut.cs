using UnityEngine;
using UnityEngine.Playables;

public class cut:MonoBehaviour
{
    public PlayableDirector cuts;

    void Start(){
        cuts.Play();
    }
}

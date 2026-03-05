using UnityEngine;
public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource source;
    public AudioSource Musicsource;
    public AudioClip switchGravity;

    public AudioClip side1;
    public AudioClip side2;
    public AudioClip side3;
    public AudioClip side4;
    public AudioClip side5;
    public AudioClip side6;

    int side = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            source.PlayOneShot(switchGravity);
        }

        if (Input.GetKeyDown(KeyCode.E)){
            source.PlayOneShot(switchGravity);
        }

        if (Input.mouseScrollDelta.y < 0){
            if (!source.isPlaying){
                source.PlayOneShot(switchGravity);
            }
            
        }

        if (Input.mouseScrollDelta.y > 0){
            if (!source.isPlaying){
                source.PlayOneShot(switchGravity);
            }
        }

        if (Input.GetKeyDown(KeyCode.V)){
            source.PlayOneShot(switchGravity);
        }

        if (Input.GetKeyDown(KeyCode.C)){
            source.PlayOneShot(switchGravity);
        }



        
    }

}

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

    private void Start()
    {
        Musicsource.clip = side5;
        Musicsource.Play();
    }

    private void Update()
    {
        Debug.Log(Physics.gravity);
        if (Physics.gravity.x <= 10f && Physics.gravity.x >= 9f)
        {
            if(side != 6)
            {
                side = 6;
                PlayMusic(side6);

            }
        }

        if (Physics.gravity.x <= -9f && Physics.gravity.x >= -10f)
        {
            if(side != 1)
            {
                side = 1;
                PlayMusic(side1);

            }        
        }
        if (Physics.gravity.y >= 9f && Physics.gravity.y <= 10f)
        {
            if(side != 2)
            {
                side = 2;
                PlayMusic(side2);

            }        
        }
        if (Physics.gravity.y >= -10f && Physics.gravity.y <= -9f)
        {
            if(side != 3)
            {
                side = 3;
                PlayMusic(side3);

            }       
            
        }
        if (Physics.gravity.z >= 9f && Physics.gravity.z <= 10f)
        {
            if(side != 4)
            {
                side = 4;
                PlayMusic(side4);

            }        
        }

        if (Physics.gravity.z >= -9f && Physics.gravity.z <= -10f)
        {
            if(side != 5)
            {
                side = 5;
                PlayMusic(side5);

            }        
        }
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

    public void PlayMusic(AudioClip musicclip)
    {
        Musicsource.Stop();
        Musicsource.clip = musicclip;
        Musicsource.Play();
    }

}

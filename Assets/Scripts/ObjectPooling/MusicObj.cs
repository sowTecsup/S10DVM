using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class MusicObj : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
            
    }
    
    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;    
        audioSource.Play();

        Invoke(nameof(ReturnToPool), audioSource.clip.length);
    }

    public void ReturnToPool()
    {
        audioSource.clip = null;
        MusicPool.OnFinishAudio?.Invoke(this);
    }


}

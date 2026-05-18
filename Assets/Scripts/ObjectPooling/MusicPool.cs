using UnityEngine;
using Sowtank.Collections;
using System;
using Sirenix.OdinInspector;

public class MusicPool : MonoBehaviour
{
    public MusicObj musicObjPrefab;

    public Queue<MusicObj> Pool = new Queue<MusicObj>();
    public int size = 20;

    public static Action<MusicObj> OnFinishAudio;


    private void OnEnable()
    {
        OnFinishAudio += EnqueueAudio;
    }

 

    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            MusicObj obj = Instantiate(musicObjPrefab, transform);
            obj.gameObject.SetActive(false);
            Pool.Enqueue(obj);
        }
    }

    public void PlayAudio(string audioName)
    {
        if(Pool.Peek().gameObject.activeSelf)
        {
            Debug.LogError("No se encontro objeto disponible");
            return;
        }

        AudioClip clip = GameManager.Instance.musicDatabase.GetAudio(audioName);
        MusicObj musicObj = Pool.Dequeue();
        musicObj.gameObject.SetActive(true);
        musicObj.PlayAudio(clip);

    }

    private void EnqueueAudio(MusicObj obj)
    {
        obj.gameObject.SetActive(false);
        Pool.Enqueue(obj);
    }

    [Button]
    public void Test(string audioName)
    {
        PlayAudio(audioName);
    }
}

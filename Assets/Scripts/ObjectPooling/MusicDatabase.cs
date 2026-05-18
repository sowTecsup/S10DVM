using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MusicDatabase", menuName = "Scriptable Objects/MusicDatabase")]
public class MusicDatabase : SerializedScriptableObject
{
    public Dictionary<string, AudioClip> AudioDatabase = new();


    public AudioClip GetAudio(string audioName)
    {
        if (AudioDatabase.TryGetValue(audioName, out AudioClip audio))
        {
            return audio;
        }
        else
            throw new System.Exception("El audio que intentas obtener no existe");
    }

}

using UnityEngine;

[System.Serializable]
public class AudioContent
{
    public AudioClip audioClip;
    [Range(0f, 1f)] // Ограничивает громкость от 0 до 1
    public float volume;
}
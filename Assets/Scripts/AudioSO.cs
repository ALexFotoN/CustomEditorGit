using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioSO", menuName = "Custom/AudioSO")]
public class AudioSo : ScriptableObject
{
    public string uniqueID;
    [TextArea(3, 10)] // Большое текстовое поле для панели
    public string panelText;
    public List<AudioContent> audioContentList = new List<AudioContent>();
    
    public AudioContentType audioContentType;
    public List<AudioContent> dangerousAudioList = new List<AudioContent>();
    public List<AudioContent> friendlyAudioList = new List<AudioContent>();
    public List<AudioContent> neutralAudioList = new List<AudioContent>();
}
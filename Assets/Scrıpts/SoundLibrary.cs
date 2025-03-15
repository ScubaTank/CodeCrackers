using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Scriptable Objects/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
    [SerializeField] AudioClip[] audioClips;

    private void Awake()
    {
      if(audioClips.Length < 26)
      {
        Debug.LogError("Audio clips are less than 26 the game should not continue.");
      }

    }

    public AudioClip GetAudioClip(int idx)
    {
        return audioClips[idx];
    }
}

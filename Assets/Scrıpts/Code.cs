using UnityEngine;

[CreateAssetMenu(fileName = "Code", menuName = "Scriptable Objects/Code")]
public class Code : ScriptableObject
{
    private AudioClip[] audioClips; //the clips of sound that make up this code. starts empty.
    [SerializeField]private string codeString; // the raw code string
    [SerializeField] private SoundLibrary soundLibrary;

    private void BuildAudioClips()
    {
        for (int i = 0; i < GetCodeLength(); i++)
        {
            audioClips[i] = soundLibrary.GetAudioClip(i);
        }
    }



    public AudioClip GetCodeSound(int idx)
    {
        return audioClips[idx];
    } 

    public int GetCodeLength()
    {
        return codeString.Length;
    }
}

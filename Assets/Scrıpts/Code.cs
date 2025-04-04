using UnityEngine;

[CreateAssetMenu(fileName = "Code", menuName = "Scriptable Objects/Code")]
public class Code : ScriptableObject
{
    private AudioClip[] audioClips; //the clips of sound that make up this code. starts empty.
    [SerializeField] private string _codeString; // the raw code string
    [SerializeField] private SoundLibrary _soundLibrary;

    public void BuildAudioClips(string scrambledCode)
    {
        //The Audioclip sequence is built from the SCRAMBLED version of the codeString.
        audioClips = new AudioClip[GetCodeLength()];
        for (int i = 0; i < GetCodeLength(); i++)
        {
            audioClips[i] = _soundLibrary.GetAudioClip(scrambledCode[i] - 'a');
        }
    }

    public AudioClip GetCodeSound(int idx)
    {
        return audioClips[idx];
    } 

    public int GetCodeLength()
    {
        return _codeString.Length;
    }

    public string GetCodeString()
    {
        return _codeString.ToLower();
    }



}

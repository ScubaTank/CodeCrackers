using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private SoundLibrary _soundLibrary;
    private AudioClip[] _codeClips;

    //This will be called the instant that a new code is selected.
    public void NewCode(Code input){

        _codeClips = new AudioClip[input.GetCodeLength()];
        for(int i = 0; i < input.GetCodeLength(); i++){
            _codeClips[i] = input.GetCodeSound(i);
        }
    }
    

    public void PlayCodeClips(){
        if (_codeClips.Length > 0)
        {
            StartCoroutine(PlaySoundsSequentially(_codeClips));
        }
        else
        {
            Debug.Log("Tried to play a sound while _codeClips was empty!");
        }
    }

    public void PlaySynthClips(string synthCode)
    {
        AudioClip[] _synthClips = new AudioClip[synthCode.Length];
        for (int i = 0; i < synthCode.Length; i++) {
            if (synthCode[i] != '_')
            {
                _synthClips[i] = _soundLibrary.GetAudioClip(synthCode[i] - 'a');
            }
        }

        StartCoroutine(PlaySoundsSequentially(_synthClips));
    }


    //taken from https://stackoverflow.com/questions/43715482/play-several-audio-clips-sequentially
    IEnumerator PlaySoundsSequentially(AudioClip[] audioClips){
        yield return null;

        for(int i = 0; i < audioClips.Length; i++){
            audioSource.clip = audioClips[i];
            audioSource.Play();
            while (audioSource.isPlaying){
                yield return null;
            }
        }
    }

    public void PlaySound(int idx)
    {
        audioSource.clip = _soundLibrary.GetAudioClip(idx);
        audioSource.Play();
    }
}

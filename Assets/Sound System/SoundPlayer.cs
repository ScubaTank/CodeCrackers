using System;
using System.Collections;
using Mono.Cecil.Cil;
using NUnit.Framework.Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    private AudioClip[] _codeClips;

    //This will be called the instant that a new code is selected.
    public void NewCode(Code input){

        _codeClips = new AudioClip[input.GetCodeLength()];
        for(int i = 0; i < input.GetCodeLength(); i++){
            _codeClips[i] = input.GetCodeSound(i);
        }
    }
    

    public void PlaySounds(){
        if (_codeClips.Length > 0)
        {
            StartCoroutine(PlaySoundsSequentially(_codeClips));
        }
        else
        {
            Debug.Log("Tried to play a sound while _codeClips was empty!");
        }
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
}

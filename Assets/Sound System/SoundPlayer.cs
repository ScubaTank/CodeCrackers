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

    //This will be called the instant that a new code is generated.
    public void NewCode(Code input){
        _codeClips = BuildCodeClips(input);
    }

    //Assuming Code objects come with functions that aid in retrieving sounds, we use the following
    private AudioClip[] BuildCodeClips(Code inputCode){
        //first, retrieve the sounds necessary based on input's properties and store them in an array.
        AudioClip[] sounds = new AudioClip[inputCode.GetCodeLength()]; //the CodeLength function should tell us how many sounds we will need.

        for(int i = 0; i < sounds.Length; i++){
            sounds[i] = inputCode.GetCodeSound(i); //CodeSound returns the audioclip necessary for the current letter, using the index as a parameter.
        }
        return sounds;
    }
    

    private void PlaySounds(AudioClip[] audioClips){
        StartCoroutine(PlaySoundsSequentially(audioClips));
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

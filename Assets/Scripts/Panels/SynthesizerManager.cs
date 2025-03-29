using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizerManager : MonoBehaviour
{
    [SerializeField] Button _confirmButton;
    [SerializeField] Button _playButton;
    [SerializeField] Button _removeButton;
    [SerializeField] Image _light;
    [SerializeField] AudioSource _audioSorce;
    [SerializeField] TMP_Text _text;

    private void Start()
    {
        gameObject.SetActive(false);

        
    }

    public void ClosePanel(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }

    public void PlayAudio()
    {
        _audioSorce.Play();
    }

}

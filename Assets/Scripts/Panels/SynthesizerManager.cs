using System;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizerManager : MonoBehaviour
{
    [SerializeField] Button _confirmButton;
    [SerializeField] Button _playButton;
    [SerializeField] Button _removeButton;
    [SerializeField] Image _light;
    [SerializeField] AudioSource _audioSorce;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }

    public void ChangeLight()
    {
        Console.WriteLine("changed color");
        _light.color = Color.green;
    }

    public void PlayAudio()
    {
        _audioSorce.Play();
    }

}

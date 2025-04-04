using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizerManager : MonoBehaviour
{

    [Header("Code Guessing")]
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private SoundPlayer _soundPlayer;
    private int _currentIdx;
    private StringBuilder _guessString;

    [Header("LightsManager")]
    [SerializeField] LightsManager _lightsManager;

    private void Awake()
    {
        _currentIdx = 0;
        _guessString = new StringBuilder("____");
        gameObject.SetActive(false);

    }

    public void ClosePanel(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }

    public void ButtonPress(string letter)
    {
        //this function's parameter SHOULD be a char, but unity won't have it show up as a button event if its a char. Amazing.
        _guessString[_currentIdx] = letter[0] ;
        UpdateTextField();
    }

    public void Confirm()
    {
        if(_currentIdx != 3 && _guessString[_currentIdx] != '_')
        {
            _currentIdx++;
        } 
        else
        {
            _lightsManager.EnableLights(_guessString.ToString());
        }
        UpdateTextField();
    }

    public void Play()
    {
        //uh oh... gotta play the sequence we built here...
        _soundPlayer.PlaySynthClips(_guessString.ToString());


    }

    public void Remove()
    {
        _guessString[_currentIdx] = '_';
        if (_currentIdx != 0)
        {
            
            _currentIdx--;
        }
        UpdateTextField();
    }

    private void UpdateTextField()
    {
        _textField.text = "Code: " + _guessString.ToString();
    }
}

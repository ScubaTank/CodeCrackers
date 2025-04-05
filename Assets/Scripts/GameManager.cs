using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _WinScreen;
    [SerializeField] private GameObject _LoseScreen;

    [Header("Code Handling")]
    [SerializeField] private float _timer;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private Code[] _codes;
    private CodeColor[] _colorSequence;
    private Code _currCode;

    public enum CodeColor { Red, Green, Blue, Yellow};

    private void Start()
    {
        PickNewCode();
    }

    public void PickNewCode()
    {
        //Clear previous values
        _currCode = null;
        _colorSequence = null;

        //get a random code
        _currCode = _codes[Random.Range(0, _codes.Length)];

        //scramble it, and build audio clips from the scrambled version.
        _currCode.BuildAudioClips(GetScrambledCode());

        //assign it to the soundPlayer.
        _soundPlayer.NewCode(_currCode);
    }

    public string GetScrambledCode()
    {
        if (_colorSequence == null)
        {
            SetColorSequence();
        }

        bool isThereRed = false;

        StringBuilder scrambledWord = new StringBuilder(_currCode.GetCodeString());

        for(int i = 3; i >= 0; i--)
        {
            if (_colorSequence[i] == CodeColor.Red)
            {
                //swap first two letters, and two last letters.
                char tempchar = scrambledWord[0];
                scrambledWord[0] = scrambledWord[1];
                scrambledWord[1] = tempchar;

                tempchar = scrambledWord[2];
                scrambledWord[2] = scrambledWord[3];
                scrambledWord[3] = tempchar;

                isThereRed = true;
            }

            //BLUE
            if (_colorSequence[i] == CodeColor.Blue)
            {
                //Debug.Log("Did blue!");
                //first, check for a red
                if (!isThereRed)
                {
                    foreach (CodeColor c in _colorSequence)
                    {
                        if (c == CodeColor.Red)
                        {
                            isThereRed = true;
                        }
                    }
                }

                //there IS red
                if (isThereRed)
                {
                    char tempchar = scrambledWord[i];
                    scrambledWord[i] = scrambledWord[3];
                    scrambledWord[3] = tempchar;
                }
            }

            //GREEN
            if (_colorSequence[i] == CodeColor.Green)
            {
                //Debug.Log("Did green!");
                //if at the ends, swap them.
                if (i == 0 || i == 3)
                {
                    char tempchar = scrambledWord[0];
                    scrambledWord[0] = scrambledWord[3];
                    scrambledWord[3] = tempchar;
                }
                else //otherwise, swap the middle.
                {
                    char tempchar = scrambledWord[1];
                    scrambledWord[1] = scrambledWord[2];
                    scrambledWord[2] = tempchar;
                }
            }

            //YELLOW
            if (_colorSequence[i] == CodeColor.Yellow)
            {

                //Debug.Log("Did yellow!");
                if (i == 3)
                {
                    char tempchar = scrambledWord[0];
                    scrambledWord[0] = scrambledWord[3];
                    scrambledWord[3] = tempchar;
                } 
                else
                {
                    char tempchar = scrambledWord[i+1];
                    scrambledWord[i+1] = scrambledWord[i];
                    scrambledWord[i] = tempchar;
                }
            }
        }


        return scrambledWord.ToString().ToLower();
    }

    public void SetColorSequence()
    {
        //sets a random color sequence with which we will encode our string.
        _colorSequence = new CodeColor[_currCode.GetCodeLength()];
        

        for (int i = 0; i < _colorSequence.Length; i++)
        {
            _colorSequence[i] = (CodeColor)Random.Range(0, 4);
        }
    }

    public void CheckAnswer(TMP_InputField input)
    {
        if (input.text ==  _currCode.GetCodeString())
        {
            PlayerWins();
        }
        else
        {
            PlayerLoses();

        }
    }

    public CodeColor[] GetColorSequence()
    {
        return _colorSequence;
    }

    private void PlayerWins()
    {
        _WinScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerLoses()
    {
        _LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public float GetTimer(){
        return _timer;
    }
}

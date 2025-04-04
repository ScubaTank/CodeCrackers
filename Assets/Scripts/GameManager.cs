using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image[] _codeLight;
    [SerializeField] private Color[] _colorArray;
    [SerializeField] private TMP_Text _text;

    [Header("Code Handling")]
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private Code[] _codes;
    private Code currCode;

    enum CodeColor { Red, Green, Blue, Yellow};

    private void Start()
    {
        PickNewCode();
        //SetColors();
        //Scrambler();
    }

    public void PickNewCode()
    {
        currCode = _codes[Random.Range(0, _codes.Length)];
        currCode.BuildAudioClips();
        _soundPlayer.NewCode(currCode);
    }

    public string Scrambler()
    {

        bool isThereRed = false;

        StringBuilder scrambledWord = new StringBuilder(currCode.GetCodeString());

        for(int i = 3; i >= 0; i--)
        {
            //RED
            if (_codeLight[i].color == _colorArray[0])
            {
                //Debug.Log("Did red!");
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
            if (_codeLight[i].color == _colorArray[1])
            {
                //Debug.Log("Did blue!");
                //first, check for a red
                if (!isThereRed)
                {
                    foreach (Image c in _codeLight)
                    {
                        if (c.color == _colorArray[0])
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
            if (_codeLight[i].color == _colorArray[2])
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
            if (_codeLight[i].color == _colorArray[3])
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
        _text.SetText("Code: " + scrambledWord.ToString());

        return scrambledWord.ToString();
    }

    public void SetColors()
    {
        foreach (Image count in _codeLight)
        {
            int index = Random.Range(0, 4);

            count.color = _colorArray[index];
        }
    }

    public void CheckAnswer(TMP_InputField input)
    {
        if (input.text ==  currCode.GetCodeString())
        {
            Debug.Log("Hooray");
        }
        else
        {
            Debug.Log("Not correct word");
        }
    }


}

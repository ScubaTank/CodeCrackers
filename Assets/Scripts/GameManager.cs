using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image[] _codeLight;
    [SerializeField] private Color[] _colorArray;
    [SerializeField] private TMP_Text _text;

    public string trueWord = "Fork";
    //private string codedWord = "";

    private void Start()
    {
        SetColors();

        Scrambler();


    }

    public string Scrambler()
    {

        bool isThereRed = false;

        StringBuilder codedWord = new StringBuilder(trueWord);

        for(int i = 3; i >= 0; i--)
        {
            //RED
            if (_codeLight[i].color == _colorArray[0])
            {
                Debug.Log("Did red!");
                //swap first two letters, and two last letters.
                char tempchar = codedWord[0];
                codedWord[0] = codedWord[1];
                codedWord[1] = tempchar;

                tempchar = codedWord[2];
                codedWord[2] = codedWord[3];
                codedWord[3] = tempchar;

                isThereRed = true;
            }

            //BLUE
            if (_codeLight[i].color == _colorArray[1])
            {
                Debug.Log("Did blue!");
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
                    char tempchar = codedWord[i];
                    codedWord[i] = codedWord[3];
                    codedWord[3] = tempchar;
                }
            }

            //GREEN
            if (_codeLight[i].color == _colorArray[2])
            {
                Debug.Log("Did green!");
                //if at the ends, swap them.
                if (i == 0 || i == 3)
                {
                    char tempchar = codedWord[0];
                    codedWord[0] = codedWord[3];
                    codedWord[3] = tempchar;
                }
                else //otherwise, swap the middle.
                {
                    char tempchar = codedWord[1];
                    codedWord[1] = codedWord[2];
                    codedWord[2] = tempchar;
                }
            }

            //YELLOW
            if (_codeLight[i].color == _colorArray[3])
            {

                Debug.Log("Did yellow!");
                if (i == 3)
                {
                    char tempchar = codedWord[0];
                    codedWord[0] = codedWord[3];
                    codedWord[3] = tempchar;
                } 
                else
                {
                    char tempchar = codedWord[i+1];
                    codedWord[i+1] = codedWord[i];
                    codedWord[i] = tempchar;
                }

                
            }

            Debug.Log("Current Word: " + codedWord.ToString());
        }

        Debug.Log("Is there a red? : " + isThereRed);

        _text.SetText("Code: " + codedWord.ToString());

        return codedWord.ToString();
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
        if (input.text ==  trueWord)
        {
            Debug.Log("Hooray");
        }
        else
        {
            Debug.Log("Not correct word");
        }
    }
}

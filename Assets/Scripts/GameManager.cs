using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image[] _codeLight;
    [SerializeField] private Color[] _colorArray;
    [SerializeField] private TMP_Text _text;

    public string trueWord = "Fork";
    private string codedWord = "";

    private void Start()
    {
        SetColors();

        //Scrambler();

        _text.SetText("Code: " + trueWord);
    }

    public string Scrambler()
    {
        string codedWord = "";

        int inArray = 0;

        //foreach (char charCount in trueWord)
        //{
        //    codedWord += trueWord[2];
        //    inArray++;
        //}

        codedWord += trueWord[2];
        codedWord += trueWord[1];
        codedWord += trueWord[4];
        codedWord += trueWord[3];


        return codedWord;
    }

    public void SetColors()
    {
        foreach (Image count in _codeLight)
        {
            int index = Random.Range(0, 3);

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

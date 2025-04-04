using UnityEngine;
using UnityEngine.UI;

public class LightsManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;

    [Header("Lights")]
    [SerializeField] Image[] BigLights;
    [SerializeField] Image[] SmallLights;

    public void EnableLights(string guessString)
    {
        //if correct, give proper colors. otherwise, give random colors.
        if (guessString == gameManager.GetScrambledCode())
        {
            for (int i = 0; i < 4; i++)
            {
                switch (gameManager.GetColorSequence()[i])
                {
                    case GameManager.CodeColor.Red:
                        BigLights[i].color = Color.red;
                        SmallLights[i].color = Color.red;
                        break;
                    case GameManager.CodeColor.Green:
                        BigLights[i].color = Color.green;
                        SmallLights[i].color = Color.green;
                        break;
                    case GameManager.CodeColor.Blue:
                        BigLights[i].color = Color.blue;
                        SmallLights[i].color = Color.blue;
                        break;
                    case GameManager.CodeColor.Yellow:
                        BigLights[i].color = Color.yellow;
                        SmallLights[i].color = Color.yellow;
                        break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {

                Color randomColor;
                switch (Random.Range(0, 4))
                {
                    case 0:
                        randomColor = Color.red;
                        break;
                    case 1:
                        randomColor = Color.green;
                        break;
                    case 2:
                        randomColor = Color.blue;
                        break;
                    default:
                        randomColor = Color.yellow;
                        break;

                }

                BigLights[i].color = randomColor;
                SmallLights[i].color = randomColor;
            }


        }
    }

    public void DisableLights()
    {
        for (int i = 0; i < 4; i++)
        {
            BigLights[i].color = Color.black; ;
            SmallLights[i].color = Color.black;
        }
    }
}

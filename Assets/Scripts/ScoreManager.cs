using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score = 0f;

    private void Update()
    {
        scoreText.SetText("Score: " + score);
    }

    public void AddScore(float value)
    {
        score += value;
    }
}

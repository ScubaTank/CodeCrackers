using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameManager _gameManager;
    private float _timerLength;

    void Awake()
    {
        _timerLength = _gameManager.GetTimer();
    }
    // Update is called once per frame
    void Update()
    {
        _timerLength -= Time.deltaTime;
        _timerText.SetText("Time: " + _timerLength + "s");

        if ( _timerLength <= 0f)
        {
            _gameManager.PlayerLoses();
            Time.timeScale = 0f;
        }
    }
}

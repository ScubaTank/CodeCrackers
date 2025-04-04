using UnityEngine;

public class SignalPanelManager : MonoBehaviour
{
    [SerializeField] SoundPlayer _soundPlayer;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }

    public void PlaySound()
    {
        _soundPlayer.PlaySounds();
    }
}

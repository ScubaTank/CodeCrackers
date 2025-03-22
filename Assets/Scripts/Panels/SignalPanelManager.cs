using UnityEngine;

public class SignalPanelManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

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
        _audioSource.Play();
    }
}

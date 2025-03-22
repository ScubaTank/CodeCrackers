using UnityEngine;

public class SignalPanelManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }
}

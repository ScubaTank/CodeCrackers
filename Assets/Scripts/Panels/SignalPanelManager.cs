using UnityEngine;

public class SignalPanelManager : MonoBehaviour
{
    public void ClosePanel(GameObject parentGameObject)
    {
        Destroy(parentGameObject);
    }
}

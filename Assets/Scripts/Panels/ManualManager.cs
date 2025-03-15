using UnityEngine;

public class ManualManager : MonoBehaviour
{
    public void ClosePanel(GameObject parentGameObject)
    {
        Destroy(parentGameObject);
    }
}

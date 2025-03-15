using UnityEngine;

public class SynthesizerManager : MonoBehaviour
{
    public void ClosePanel(GameObject parentGameObject)
    {
        Destroy(parentGameObject);
    }
}

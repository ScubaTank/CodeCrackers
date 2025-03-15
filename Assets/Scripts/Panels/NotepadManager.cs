using UnityEngine;

public class NotepadManager : MonoBehaviour
{
    public void ClosePanel(GameObject parentGameObject)
    {
        Destroy(parentGameObject);
    }
}

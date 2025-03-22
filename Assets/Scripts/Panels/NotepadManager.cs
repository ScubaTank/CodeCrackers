using UnityEngine;

public class NotepadManager : MonoBehaviour
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

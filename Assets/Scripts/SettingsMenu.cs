using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void CloseMenu(GameObject parentGameObject)
    {
        parentGameObject.SetActive(false);
    }
}

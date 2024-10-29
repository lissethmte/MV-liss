using UnityEngine;

public class TreePanelController : MonoBehaviour
{
    public GameObject treePanel; 

    void Start()
    {
        
        if (treePanel != null)
        {
            treePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("El panel no está asignado en el inspector.");
        }
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleTreePanel();
        }
    }

    void ToggleTreePanel()
    {
        if (treePanel != null)
        {
            
            treePanel.SetActive(!treePanel.activeSelf);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesController : MonoBehaviour
{
    public GameObject treePanel; 
    public Button startButton;
    public Button quitButton;

    private bool isTreePanelActive = false;

    void Start()
    {
       
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

       
        if (treePanel != null)
        {
            treePanel.SetActive(false);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleTreePanel();
        }
    }

    void StartGame()
    {
       
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("Juego cerrado"); 
    }

    void ToggleTreePanel()
    {
        
        isTreePanelActive = !isTreePanelActive;
        treePanel.SetActive(isTreePanelActive);
    }
}

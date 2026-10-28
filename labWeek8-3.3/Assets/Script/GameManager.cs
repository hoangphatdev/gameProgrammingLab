using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Canvas GameMenu;
    private bool isShowingMenu = true;
    public TMP_Text Title;
    public TMP_Text Message;
    public Button EnterButton;
    public Button RestartButton;

    void Start()
    {
        GameMenu.enabled = isShowingMenu;        
        Title.text = "Welcome to the Game!";
        Message.text = "Do you want to continue?";
        EnterButton.GetComponentInChildren<TMP_Text>().text = "Enter";
        RestartButton.GetComponentInChildren<TMP_Text>().text = "Restart";

        EnterButton.onClick.AddListener(OnButtonClicked);
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
    }
    
    void OnButtonClicked()
    {
        GameMenu.enabled = !isShowingMenu;
    }

    void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        
    }
}

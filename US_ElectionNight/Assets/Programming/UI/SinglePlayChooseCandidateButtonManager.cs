using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SinglePlayChooseCandidateButtonManager : MonoBehaviour
{
    public Button backButton;
    public Button shopButton;
    public Button nextButton;

    private void Start()
    {
        backButton.onClick.AddListener(LoadMainMenu);
        shopButton.onClick.AddListener(LoadShop);
        nextButton.onClick.AddListener(LoadGameScene);

        SetNextButtonActive(false);
    }

    internal void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    internal void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    internal void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetNextButtonActive(bool isActive)
    {
        nextButton.interactable = isActive;
        Color buttonColor = isActive ? Color.white : Color.gray;
        nextButton.GetComponent<Image>().color = buttonColor;
    }
}

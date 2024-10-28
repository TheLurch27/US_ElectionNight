using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    public Button feedbackButton;
    public Button settingsButton;
    public Button singlePlayButton;
    public Button playWithFriendsButton;
    public Button passAndPlayButton;
    public Button findAGameButton;
    public Button shopButton;

    private void Start()
    {
        // Weist den Buttons die entsprechenden Methoden zu
        feedbackButton.onClick.AddListener(LoadFeedbackScene);
        settingsButton.onClick.AddListener(LoadSettingsScene);
        singlePlayButton.onClick.AddListener(LoadSinglePlayChooseCandidatesScene);
        playWithFriendsButton.onClick.AddListener(LoadPlayWithFriendsScene);
        passAndPlayButton.onClick.AddListener(LoadPassAndPlayChooseCandidatesScene);
        findAGameButton.onClick.AddListener(LoadFindAGameScene);
        shopButton.onClick.AddListener(LoadShopScene);
    }

    private void LoadFeedbackScene()
    {
        SceneManager.LoadScene("FeedbackScene");
    }

    private void LoadSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    private void LoadSinglePlayChooseCandidatesScene()
    {
        SceneManager.LoadScene("SinglePlay_ChooseCandidates");
    }

    private void LoadPlayWithFriendsScene()
    {
        SceneManager.LoadScene("PlayWithFriendsScene");
    }

    private void LoadPassAndPlayChooseCandidatesScene()
    {
        SceneManager.LoadScene("PassAndPlay_ChooseCandidatesScene");
    }

    private void LoadFindAGameScene()
    {
        SceneManager.LoadScene("FindAGameScene");
    }

    private void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }
}

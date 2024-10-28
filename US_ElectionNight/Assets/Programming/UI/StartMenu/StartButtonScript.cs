using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

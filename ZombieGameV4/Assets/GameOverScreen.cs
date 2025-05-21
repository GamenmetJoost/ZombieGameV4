using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f; // Reset de tijd
        SceneManager.LoadScene("SampleScene"); // Verwijder het sterretje!
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        Debug.Log("ExitButton pressed - Application.Quit() called");
        Application.Quit();
    }
}
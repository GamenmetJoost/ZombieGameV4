using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Start()
    {
        Show_Screen();
        Time.timeScale = 0f; // Pauzeer het spel bij start
    }

    public void Show_Screen()
    {
        gameObject.SetActive(true);
    }

    public void StartButton() 
    {
        Time.timeScale = 1f; // Zet het spel weer aan
        gameObject.SetActive(false); // Verberg het startscherm
        // SceneManager.LoadScene("SampleScene"); 
    }

    public void QuitButton()
    {
        Time.timeScale = 1f;
        Debug.Log("ExitButton pressed - Application.Quit() called");
        Application.Quit();
    }
}
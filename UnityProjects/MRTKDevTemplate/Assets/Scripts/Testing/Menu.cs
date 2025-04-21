using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuUI;        // The menu panel
    public GameObject gameContent;   // The object to show when "Play" is clicked

    public void Play()
    {
        gameContent.SetActive(true);
        menuUI.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit Game");

        // Stop play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;

        // Quit the application in a build
        Application.Quit();
    }
}


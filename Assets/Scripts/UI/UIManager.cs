using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BacktoMainMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
    }

    public void PlayGame()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Game");
    }
    public void Credits()
    {
        Debug.Log("credits" );
        SceneManager.LoadScene("Credits");

    }
    public void BacktoMainMenu()
    {
        Debug.Log("main menu");
        SceneManager.LoadScene("Main Menu");

    }

    public void QuitGame()
    {
        Debug.Log("quiteaste");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

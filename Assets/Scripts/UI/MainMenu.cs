using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button playButton;
    [SerializeField] UnityEngine.UI.Button exitButton;
    [SerializeField] UI_Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
        playButton.onClick.AddListener(PlayGame);
        settings = FindObjectOfType<UI_Settings>();
    }

    void ExitGame()
    { 
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
    void PlayGame()
    {
        settings.SetValuaToPlay();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    
}

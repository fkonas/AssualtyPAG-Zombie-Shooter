using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highScoreUI;

    string newGameScene = "Level1";

    public AudioSource main_music;

    void Start()
    {
        main_music = GetComponent<AudioSource>();
        main_music.Play();

        // Set the high score text

        int highScore = SaveLoadManager.Instance.LoadHighScore();
        highScoreUI.text = $"Top Wave Survived: {highScore}";
    }
    
    public void StartNewGame()
    {
        main_music.Stop();

        SceneManager.LoadScene(newGameScene);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else

#endif
    }

}

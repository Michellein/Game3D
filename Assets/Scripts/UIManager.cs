using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject lose, win;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void OnWin()
    {
        win.SetActive(true);
    }

    public void OnLose()
    {
        lose.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
}

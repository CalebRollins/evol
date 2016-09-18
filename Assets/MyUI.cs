using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyUI : MonoBehaviour {

    public Text text;
    public void Start ()
    {
        text.enabled = false;
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit ()
    {
        Application.Quit();
    }

    public void InfoMouseEnter ()
    {
        text.enabled = true;
    }

    public void InfoMouseExit ()
    {
        text.enabled = false;
    }
}

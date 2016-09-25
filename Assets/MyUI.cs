using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyUI : MonoBehaviour {

    public Text infoText;
    public Text endText;

    public void Start ()
    {
        infoText.enabled = false;
        endText.enabled = false;
    }

    public void End ()
    {
        endText.enabled = true;
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
        infoText.enabled = true;
    }

    public void InfoMouseExit ()
    {
        infoText.enabled = false;
    }
}

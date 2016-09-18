using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyUI : MonoBehaviour {

	public void restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

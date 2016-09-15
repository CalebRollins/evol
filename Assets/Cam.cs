using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Vector3 focus;

    void Start()
    {
        focus = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, focus, 5.0f * Time.deltaTime);
    }
}

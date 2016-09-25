using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Vector3 focus;
    public float speed;
    void Start()
    {
        focus = new Vector3(0, 0, 0);
        speed = 5.0F;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, focus, speed * Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;

public class Biomorph : MonoBehaviour {
    public Mesh mesh;
    public Material material;
    public 
	void Start ()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        Development.Develop(this);
        Reproduction.Reproduce(this);
	}
}

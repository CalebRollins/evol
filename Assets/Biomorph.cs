using UnityEngine;
using System.Collections;

public class Biomorph : MonoBehaviour {
    private const int max = 100;
    private static int num = 0;
    public static bool[,,] taken = new bool[DNA.geneMaxVal+1, DNA.geneMaxVal+1, DNA.geneMaxVal+1]; // taken spots/DNA combinations
    public Mesh mesh;
    public Material material;
    public DNA dna;

	void Start ()
    {
        StartCoroutine(Init());
	}   

    private IEnumerator Init ()
    {
        yield return new WaitForSeconds(0.1f);
        if (num++ > max) yield break;
        if (dna == null) dna = new DNA();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.color = 
            new Color((float)dna.genes[0] / (DNA.geneMaxVal + 1F), (float)dna.genes[1] / (DNA.geneMaxVal + 1F), (float)dna.genes[2] / (DNA.geneMaxVal + 1F));
        Development.Develop(this);
        Reproduction.Reproduce(this);
    }
}
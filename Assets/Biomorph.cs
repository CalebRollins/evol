using UnityEngine;
using System.Collections;

public class Biomorph : MonoBehaviour {
    public Cam cam;
    private const int max = 500;
    public int ID;
    public static bool[,,] taken = new bool[DNA.geneMaxVal+1, DNA.geneMaxVal+1, DNA.geneMaxVal+1]; // taken spots/DNA combinations
    public Material material;
    public GameObject prefab;
    public DNA dna;
    public bool firstBiomorph; // set this in the inspector

	void Start ()
    {
        if (firstBiomorph) firstBiomorphSetup();
        cam.focus = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
        StartCoroutine(Init());
	}   

    private IEnumerator Init ()
    {
        yield return new WaitForSeconds(1f);
        if (++ID >= max - 1) yield break;
        Development.Develop(this);
        //Reproduction.Reproduce(this);
    }

    private void firstBiomorphSetup()
    {
        dna = new DNA();
        ID = -1;
        taken[dna.genes[0], dna.genes[1], dna.genes[2]] = true;

        firstBiomorph = false;
    }
}
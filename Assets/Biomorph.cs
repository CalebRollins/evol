using UnityEngine;
using System.Collections;

public class Biomorph : MonoBehaviour {
    public Cam cam;
    private const int max = 250;
    public int ID;
    public static bool[,,] taken = new bool[DNA.geneMaxVal+1, DNA.geneMaxVal+1, DNA.geneMaxVal+1]; // taken spots/DNA combinations
    public Material material;
    public GameObject prefab;
    public DNA dna;
    public bool firstBiomorph; // set this in the inspector
    public const int distBetweenBiomorphs = 30;

    void Start ()
    {
        if (firstBiomorph) firstBiomorphSetup();
        
        StartCoroutine(Init());
    }   

    private IEnumerator Init ()
    { 
        Debug.Log("Genes: " + dna.genes[0] + " " + dna.genes[1] + " " + dna.genes[2]);
        yield return new WaitForSeconds(.1f);
        if (++ID >= max - 1) yield break;
        
        Development.Develop(this);
        cam.focus = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 25f);
        Reproduction.Reproduce(this);

    }

    private void firstBiomorphSetup()
    {
        dna = new DNA();
        ID = -1;
        taken[dna.genes[0], dna.genes[1], dna.genes[2]] = true;
        transform.position = new Vector3(distBetweenBiomorphs * (DNA.geneMaxVal - 1) / 2, distBetweenBiomorphs * (DNA.geneMaxVal - 1) / 2, distBetweenBiomorphs * (DNA.geneMaxVal - 1) / 2);
        firstBiomorph = false;
    }
}
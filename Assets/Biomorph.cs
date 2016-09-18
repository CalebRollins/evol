using UnityEngine;
using System.Collections;

public class Biomorph : MonoBehaviour {
    public Cam cam;
    private const int max = 100;
    public int ID;
    public static bool[,,] taken = new bool[DNA.geneMaxVal+1, DNA.geneMaxVal+1, DNA.geneMaxVal+1]; // taken spots/DNA combinations
    public Material material;
    public GameObject prefab;
    public DNA dna;
    public bool firstBiomorph; // set this in the inspector
    public const int distBetweenBiomorphs = 100;
    private float originalY;
    private const float floatStrength = 5;
    private float seed;

    void Start ()
    {
        if (firstBiomorph) firstBiomorphSetup();
        
        StartCoroutine(Init());
    }   
    
    void Update ()
    {
        transform.position = new Vector3(transform.position.x,
        originalY + ((float)Mathf.Sin(Time.time * seed) * floatStrength),
        transform.position.z);
    }

    private IEnumerator Init ()
    { 
        Debug.Log("Genes: " + dna.genes[0] + " " + dna.genes[1] + " " + dna.genes[2]);
        originalY = transform.position.y;
        seed = Random.Range(1.0F, 1.5F);
        cam = GameObject.Find("Cam").GetComponent<Cam>();

        yield return new WaitForSeconds(3f);
        if (++ID >= max - 1) yield break;
        
        Development.Develop(this);

        cam.focus = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 75F);
        Reproduction.Reproduce(this);

    }

    private void firstBiomorphSetup()
    {
        dna = new DNA();
        ID = -1;
        taken[dna.genes[0], dna.genes[1], dna.genes[2]] = true;
        transform.position = new Vector3(distBetweenBiomorphs * dna.genes[0], distBetweenBiomorphs * dna.genes[1], distBetweenBiomorphs * dna.genes[2]);

        firstBiomorph = false;
    }
}
using UnityEngine;
using System.Collections;

public static class Development
{
	public static void Develop (Biomorph biomorph)
    {
        int levels = biomorph.dna.genes[0];
        
        int[] genes = biomorph.dna.genes;
        GameObject go = GameObject.Instantiate(biomorph.prefab, biomorph.transform.position, Quaternion.identity) as GameObject;
        Color color = new Color((float)genes[0] / (DNA.geneMaxVal + 1F), (float)genes[1] / (DNA.geneMaxVal + 1F), (float)genes[2] / (DNA.geneMaxVal + 1F));
        Vector3 scale = Vector3.Scale(go.transform.localScale, new Vector3(1F - genes[1] + 1 / 10.0F, (genes[1] + 1) / 10.0F, 1F - genes[1] / 10.0F));
        Initialize(go, biomorph.gameObject, color, scale);
        Fractal(go, levels, biomorph, color, scale);
    }

    public static void Fractal (GameObject parent, int levels, Biomorph biomorph, Color color, Vector3 scale)
    {
        if (levels <= 0) return;

        levels--;

        GameObject go = GameObject.Instantiate(biomorph.prefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject go2 = GameObject.Instantiate(biomorph.prefab, Vector3.zero, Quaternion.identity) as GameObject;

        Initialize(go, parent, color, scale);
        Initialize(go2, parent, color, scale);

        Vector3 spawnPoint = parent.transform.GetChild(1).transform.position;
        go.transform.position = spawnPoint;
        go2.transform.position = spawnPoint;

        go.transform.localRotation = Quaternion.Euler(0f, 0f, -45f);
        go2.transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
        Fractal(go, levels, biomorph, color, scale);
        Fractal(go2, levels, biomorph, color, scale);
    }

    public static void Initialize(GameObject go, GameObject parent, Color color, Vector3 scale)
    {
        go.transform.parent = parent.transform;
        
        GameObject model = go.transform.GetChild(0).gameObject;
        model.GetComponent<MeshRenderer>().material.color = color;
       
        //go.transform.localScale = scale;
    }
}

using UnityEngine;
using System.Collections.Generic;

public static class Development
{
	public static void Develop (Biomorph biomorph)
    {
        int levels = biomorph.dna.genes[0];
        
        int[] genes = biomorph.dna.genes;
        
        Color color = new Color((float)genes[0] / (DNA.geneMaxVal + 1F), (float)genes[1] / (DNA.geneMaxVal + 1F), (float)genes[2] / (DNA.geneMaxVal + 1F));

        int scaleFactor = biomorph.dna.genes[2];
        Vector3 scale = new Vector3((10F - scaleFactor) / 2F, (scaleFactor + 1) / 2F, (10F - scaleFactor) / 2F);
        GameObject go = GameObject.Instantiate(biomorph.prefab, biomorph.transform.position, Quaternion.identity) as GameObject;
        GameObject goToInstantiate = GameObject.Instantiate(biomorph.prefab, Vector3.zero, Quaternion.identity) as GameObject;
        goToInstantiate.transform.localScale = scale;

        Initialize(go, biomorph.gameObject, color);
        Fractal(go, levels, biomorph, color, goToInstantiate);

    }

    public static void Fractal (GameObject parent, int levels, Biomorph biomorph, Color color, GameObject goToInstantiate)
    {
        if (levels <= 0) return;

        levels--;

        GameObject go = GameObject.Instantiate(goToInstantiate, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject go2 = GameObject.Instantiate(goToInstantiate, Vector3.zero, Quaternion.identity) as GameObject;

        Initialize(go, parent, color);
        Initialize(go2, parent, color);

        Vector3 spawnPoint = parent.transform.GetChild(1).transform.position;
        go.transform.position = spawnPoint;
        go2.transform.position = spawnPoint;

        int angle = (biomorph.dna.genes[1] + 1) * 10;
        go.transform.localRotation = Quaternion.Euler(0f, 0f, -(float)angle);
        go2.transform.localRotation = Quaternion.Euler(0f, 0f, (float)angle);

        Fractal(go, levels, biomorph, color, goToInstantiate);
        Fractal(go2, levels, biomorph, color, goToInstantiate);
    }

    public static void Initialize(GameObject go, GameObject parent, Color color)
    {
        go.transform.parent = parent.transform;
        
        GameObject model = go.transform.GetChild(0).gameObject;
        model.GetComponent<MeshRenderer>().material.color = color;
    }
}

using UnityEngine;
using System.Collections.Generic;

public static class Development
{
	public static void Develop (Biomorph biomorph)
    {
        int levels = biomorph.dna.genes[0];
        
        int[] genes = biomorph.dna.genes;
        
        Color color = new Color((float)genes[0] / (DNA.geneMaxVal + 1F), (float)genes[1] / (DNA.geneMaxVal + 1F), (float)genes[2] / (DNA.geneMaxVal + 1F));
        CreateEndCap(biomorph.transform, biomorph.transform.position, color);
        GameObject go = GameObject.Instantiate(biomorph.prefab, biomorph.transform.position, Quaternion.identity) as GameObject;
        float stretchAmount = biomorph.dna.genes[2] / 3F;
        Initialize(go, biomorph.gameObject, color);
        Fractal(go, levels, biomorph, color);
        
    }

    public static void Stretch (GameObject original, float stretchAmount)
    {
        Vector3[] verts = original.transform.GetChild(0).GetComponent<MeshFilter>().mesh.vertices; // get all vertices from model
        for (int i = 0; i < verts.Length; i++)
        {
            if(verts[i].y > 0F)
            {
                verts[i] += Vector3.up * stretchAmount; 
            }
        }
        original.transform.GetChild(0).GetComponent<MeshFilter>().mesh.vertices = verts;
        original.transform.GetChild(1).transform.position += Vector3.up * stretchAmount; // move up spawn point
    }

    public static void Fractal (GameObject parent, int levels, Biomorph biomorph, Color color)
    {
        if (levels <= 0)
        {
            CreateEndCap(parent.transform, parent.transform.GetChild(1).transform.position, color);
            return;
        }

        levels--;

        GameObject go = GameObject.Instantiate(parent, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject go2 = GameObject.Instantiate(parent, Vector3.zero, Quaternion.identity) as GameObject;

        Initialize(go, parent, color);
        Initialize(go2, parent, color);

        Vector3 spawnPoint = parent.transform.GetChild(1).transform.position;
        go.transform.position = spawnPoint;
        go2.transform.position = spawnPoint;

        int angle = (biomorph.dna.genes[1] + 1) * 9;
        go.transform.localRotation = Quaternion.Euler(0f, 0f, -(float)angle);
        go2.transform.localRotation = Quaternion.Euler(0f, 0f, (float)angle);

        Fractal(go, levels, biomorph, color);
        Fractal(go2, levels, biomorph, color);
    }

    public static void CreateEndCap (Transform parent, Vector3 position, Color color)
    {
        GameObject go = GameObject.Instantiate(Resources.Load("Sphere"), position, Quaternion.identity) as GameObject;
        go.GetComponent<MeshRenderer>().material.color = color;
        go.transform.parent = parent;
    }

    public static void Initialize(GameObject go, GameObject parent, Color color)
    {
        go.transform.SetParent(parent.transform, true);
        
        GameObject model = go.transform.GetChild(0).gameObject;
        model.GetComponent<MeshRenderer>().material.color = color;
    }
}

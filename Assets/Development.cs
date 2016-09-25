using UnityEngine;
using System.Collections.Generic;

public static class Development
{
	public static void Develop (Biomorph biomorph)
    {
        int levels = biomorph.dna.genes[0] + 1;
        
        int[] genes = biomorph.dna.genes;
        
        biomorph.color = new Color((float)genes[0] / (DNA.geneMaxVal + 1F), (float)genes[1] / (DNA.geneMaxVal + 1F), (float)genes[2] / (DNA.geneMaxVal + 1F));
        biomorph.scale = (biomorph.dna.genes[2] + 1.0F) / 3.5F;
        CreateEndCap(biomorph.transform, biomorph.transform.position, biomorph.color, biomorph.scale);
        GameObject trunk = GameObject.Instantiate(biomorph.prefab, biomorph.transform.position, Quaternion.identity) as GameObject;
        
        ScaleCylinder(trunk, biomorph.scale);
        Initialize(trunk, biomorph.gameObject, biomorph.color);
        Fractal(trunk, levels, biomorph); 
    }

    public static void ScaleCylinder (GameObject original, float stretchAmount)
    {
        Vector3[] verts = original.transform.GetChild(0).GetComponent<MeshFilter>().mesh.vertices; // get all vertices from model

        for (int i = 0; i < verts.Length; i++)
        {
            verts[i] = Vector3.Scale(verts[i], new Vector3(stretchAmount, 1.0F, stretchAmount));
            //if (verts[i].y > 0F) verts[i] += Vector3.up * stretchAmount;
        }
        original.transform.GetChild(0).GetComponent<MeshFilter>().mesh.vertices = verts;
        //original.transform.GetChild(1).transform.position += Vector3.up * stretchAmount; // move up spawn point
    }

    public static void Fractal (GameObject parent, int levels, Biomorph biomorph)
    {
        if (levels <= 0)
        {
            CreateEndCap(parent.transform, parent.transform.GetChild(1).transform.position, biomorph.color, biomorph.scale);
            return;
        }

        levels--;

        GameObject branch1 = GameObject.Instantiate(parent, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject branch2 = GameObject.Instantiate(parent, Vector3.zero, Quaternion.identity) as GameObject;

        Initialize(branch1, parent, biomorph.color);
        Initialize(branch2, parent, biomorph.color);

        Vector3 spawnPoint = parent.transform.GetChild(1).transform.position;
        branch1.transform.position = spawnPoint;
        branch2.transform.position = spawnPoint;

        float angle = (biomorph.dna.genes[1] + 1) * (90F / (DNA.geneMaxVal + 1));
        branch1.transform.localRotation = Quaternion.Euler(0f, 0f, -(float)angle);
        branch2.transform.localRotation = Quaternion.Euler(0f, 0f, (float)angle);

        Fractal(branch1, levels, biomorph);
        Fractal(branch2, levels, biomorph);
    }

    public static void CreateEndCap (Transform parent, Vector3 position, Color color, float scale)
    {
        GameObject go = GameObject.Instantiate(Resources.Load("Sphere"), position, Quaternion.identity) as GameObject;
        go.GetComponent<MeshRenderer>().material.color = color;
        go.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        go.transform.parent = parent;
    }

    public static void Initialize(GameObject go, GameObject parent, Color color)
    {
        go.transform.SetParent(parent.transform, true);
        
        GameObject model = go.transform.GetChild(0).gameObject;
        model.GetComponent<MeshRenderer>().material.color = color;
    }
}

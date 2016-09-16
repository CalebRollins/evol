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
        Initialize(go, biomorph.gameObject, color);
        Fractal(go, levels, biomorph, color);
            //go.transform.localScale = Vector3.Scale(go.transform.localScale, new Vector3(1F - genes[1] + 1 / 10.0F, (genes[1] + 1) / 10.0F, 1F - genes[1] / 10.0F));
        
    }

    public static void Fractal (GameObject parent, int levels, Biomorph biomorph, Color color)
    {
        if (levels < 0) return;

        levels--;

        GameObject go = GameObject.Instantiate(biomorph.prefab, new Vector3(parent.transform.position.x - 1, parent.transform.position.y+2), Quaternion.identity) as GameObject;
        GameObject go2 = GameObject.Instantiate(biomorph.prefab, new Vector3(parent.transform.position.x + 1, parent.transform.position.y + 2), Quaternion.identity) as GameObject;

        Initialize(go, parent, color);
        Initialize(go2, parent, color);

        Fractal(go, levels, biomorph, color);
        Fractal(go2, levels, biomorph, color);
    }

    public static void Initialize(GameObject go, GameObject parent, Color color)
    {
        go.transform.parent = parent.transform;
        GameObject model = go.transform.GetChild(0).gameObject;
        model.GetComponent<MeshRenderer>().material.color = color;
    }
}

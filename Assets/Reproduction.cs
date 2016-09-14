using UnityEngine;
using System.Collections;

public static class Reproduction
{

	public static void Reproduce (Biomorph biomorph)
    {
        DNA newDna = MutateDNA(biomorph.dna);
        GameObject go = GameObject.Instantiate(biomorph.gameObject, 
            biomorph.transform.TransformPoint(GeneDiff(biomorph.dna, newDna)), Quaternion.identity) as GameObject;
        go.GetComponent<Biomorph>().dna = new DNA(newDna);
    }

    public static DNA MutateDNA (DNA dna)
    {
        DNA newDna = new DNA(dna);

        int geneToMutate = Random.Range(0, newDna.genes.Length);
        newDna.genes[geneToMutate] = MutateGene(newDna.genes[geneToMutate]);

        return newDna;
    }

    public static int MutateGene (int gene)
    {
        // randomly adds or subtracts 1
        int change = Random.Range(1, 3) * 2 - 3;
        return gene + change;
    }

    public static Vector3 GeneDiff (DNA dna1, DNA dna2)
    {
        return Vector3.Scale(
            new Vector3(dna1.genes[0], dna1.genes[1], dna1.genes[2]) - new Vector3(dna2.genes[0], dna2.genes[1], dna2.genes[2]),
            new Vector3(3,3,3));
    }
}

using UnityEngine;
using System.Collections;

public static class Reproduction
{

	public static void Reproduce(Biomorph biomorph)
    {
        MutateDNA(biomorph.dna);
        GameObject.Instantiate(biomorph, new Vector3(1, 1, 1), Quaternion.identity);
    }

    public static void MutateDNA(DNA dna)
    {
        MutateGene(ref dna.genes[Random.Range(0, dna.genes.Length)]);
    }

    public static void MutateGene(ref int gene)
    {
        // randomly adds or subtracts 1
        gene += Random.Range(1, 3) * 2 - 3;
    }
}

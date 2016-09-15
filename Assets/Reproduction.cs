using UnityEngine;
using System.Collections;

public static class Reproduction
{

	public static void Reproduce (Biomorph biomorph)
    {
        // prevent biomorph from reproducing if surrounded
        if (DeadEnd(biomorph.dna.genes))
        {
            Debug.Log("All Done!");
            return; 
        }
        DNA newDna = MutateDNA(biomorph.dna);
        GameObject go = GameObject.Instantiate(biomorph.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        
        go.GetComponent<Biomorph>().dna = newDna;
        const int distBetweenBiomorphs = 4;
        go.transform.position = biomorph.transform.TransformPoint( Vector3.Scale(GeneDiff(biomorph.dna, newDna), 
                                              new Vector3(distBetweenBiomorphs, distBetweenBiomorphs, distBetweenBiomorphs)));
    }

    public static DNA MutateDNA (DNA dna)
    {
        DNA newDna;
        int gene;
        do
        {
            newDna = new DNA(dna); // start from scratch each time
            int geneToMutate = Random.Range(0, newDna.genes.Length);
            gene = MutateGene(newDna.genes[geneToMutate]);
            newDna.genes[geneToMutate] = gene;
        } while (gene < 0 || gene > DNA.geneMaxVal || Biomorph.taken[newDna.genes[0], newDna.genes[1], newDna.genes[2]]);

        Biomorph.taken[newDna.genes[0], newDna.genes[1], newDna.genes[2]] = true;

        return newDna;
    }
    
    // randomly adds or subtracts 1 to gene's value
    public static int MutateGene (int gene)
    {
        int change = Random.Range(1, 3) * 2 - 3;
        return gene + change;
    }

    // returns difference between two DNA sequences as a Vector3
    public static Vector3 GeneDiff (DNA dna1, DNA dna2)
    {
        return new Vector3(dna1.genes[0], dna1.genes[1], dna1.genes[2]) - new Vector3(dna2.genes[0], dna2.genes[1], dna2.genes[2]);
    }

    // checks if biomorph is completely surrounded
    public static bool DeadEnd (int[] genes)
    {
        for (int x = genes[0] - 1; x <= genes[0] + 1; x++)
        {
            if (x < 0 || x > DNA.geneMaxVal) continue;
            for (int y = genes[1] - 1; y <= genes[1] + 1; y++)
            {
                if (y < 0 || y > DNA.geneMaxVal) continue;
                for (int z = genes[2] - 1; z <= genes[2] + 1; z++)
                {
                    if (z < 0 || z > DNA.geneMaxVal) continue;
                    if (x == genes[0] && y == genes[1] && z == genes[2]) continue;
                    if (!Biomorph.taken[x, y, z]) return false;
                }
            }
        }
        return true;
    }
}

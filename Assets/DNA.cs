using UnityEngine;
using System.Collections;

public class DNA 
{
    // controls Red and levels of Recursion
    // controls Green and Girth of branches
    // controls Blue and angle of Branches
    private const int numGenes = 3;
    public const int geneMaxVal = 9;
    public int[] genes = new int[numGenes];

    public DNA ()
    {
        for (int i = 0; i < numGenes; i++) genes[i] = (geneMaxVal - 1) / 2;
    }

    // create clone
    public DNA (DNA original)
    {
        for (int i = 0; i < numGenes; i++) genes[i] = original.genes[i];
    }
}

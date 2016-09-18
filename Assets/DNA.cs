using UnityEngine;
using System.Collections;

public class DNA 
{

    private const int numGenes = 3;
    public const int geneMaxVal = 7; // 0 to ...
    public int[] genes = new int[numGenes];
    // [0] controls Red, levels of Recursion, x
    // [1] controls Green, Girth of branches, y
    // [2] controls Blue, angle of Branches, z

    public DNA ()
    {
        for (int i = 0; i < numGenes; i++) genes[i] = 7;
        genes[2] = 0;
        //(geneMaxVal - 1) / 
    }

    // create clone
    public DNA (DNA original)
    {
        for (int i = 0; i < numGenes; i++) genes[i] = original.genes[i];
    }
}

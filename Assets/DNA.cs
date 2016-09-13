using UnityEngine;
using System.Collections;

public class DNA 
{
    private int geneR; // controls Red and levels of Recursion
    private int geneG; // controls Green and Girth of branches
    private int geneB; // controls Blue and angle of Branches
    public int[] genes;

    public DNA ()
    {
        for (int i = 0; i < genes.Length; i++) genes[i] = 0;
    }


	
}

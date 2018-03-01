using UnityEngine;
using Genetics.Genes;

[System.Serializable]
public class BodyChromosome{

    [SerializeField]
    Gene[] genes = new Gene[] { new FloatGene(1f), new BoolGene(false), new IntGene(1), new ColorGene(Color.clear), new FloatGene(1f)};

    [SerializeField]
    FloatGene height;
    [SerializeField]
    FloatGene heightRecessive;

}

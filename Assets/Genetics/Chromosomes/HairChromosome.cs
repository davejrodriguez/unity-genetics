using Genetics.Genes;

namespace Genetics.Chromosomes {

    [System.Serializable]
    public class HairChromosome {

        [UnityEngine.SerializeField]
        FloatGene Length;
        [UnityEngine.SerializeField]
        ColorGene Color;

    }

}

using System;

namespace Genetics {

    [Serializable]
    public enum Dominance {
        Dominant,
        Recessive
    }

    [Serializable]
    public enum Zygosity {
        Homozygous,
        Heterozygous,
        Hemizygous,
        Nullizygous
    }

    public enum NucleotideBase {
        Adenine,
        Thymine,
        Guanine,
        Cytosine
    }

    public enum ChromosomeType {
        Autosome,
        Allosome
    }

}

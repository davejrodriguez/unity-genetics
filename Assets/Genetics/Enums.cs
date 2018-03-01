using System;

namespace Genetics {

    [Serializable]
    public enum Dominance {
        Dominant,
        Recessive
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

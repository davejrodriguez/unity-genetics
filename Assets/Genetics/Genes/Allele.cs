namespace Genetics.Genes {
    public class Allele : Gene {
        public Allele(string name, object value, Zygosity zygosity, Dominance dominance, float mutationProbability) : base(name, value, zygosity, dominance, mutationProbability) {
        }
    }

    public class Allele<T> : Allele {

        public virtual new T Value { get; set; }

        public Allele(string name, T value, Zygosity zygosity, Dominance dominance, float mutationProbability) : base(name,value, zygosity, dominance, mutationProbability) {
            Value = value;
        }
    }

}

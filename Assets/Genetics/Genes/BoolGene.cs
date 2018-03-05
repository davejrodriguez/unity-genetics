using System;

namespace Genetics.Genes {

    [Serializable]
    public class BoolGene : Gene<bool> {

        public BoolGene(string _name, bool _value) : this(_name, _value, Zygosity.Homozygous, Dominance.Dominant, 0f) { }
        public BoolGene(string _name, bool _value, Zygosity _zygosity, Dominance _dominance, float _mutationProbability) : base(_name, _value, _zygosity, _dominance, _mutationProbability) {
            OnMutationSucceeded += BoolGene_OnMutationSucceeded;
        }

        private void BoolGene_OnMutationSucceeded() {
            Value = Random.NextDouble() > .5;
        }

    }

}


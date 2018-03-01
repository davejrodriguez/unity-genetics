using System;

namespace Genetics.Genes {

    [Serializable]
    public class BoolGene : Gene<bool> {

        public BoolGene(bool _value) : this(_value, Dominance.Dominant, 0f) { }
        public BoolGene(bool _value, Dominance _dominance) : this(_value, _dominance, 0f) { }
        public BoolGene(bool _value, Dominance _dominance, float _mutationProbability) : base(_value, _dominance, _mutationProbability) {
            OnMutationSucceeded += BoolGene_OnMutationSucceeded;
        }

        private void BoolGene_OnMutationSucceeded() {
            Value = Random.NextDouble() > .5;
        }

    }

}


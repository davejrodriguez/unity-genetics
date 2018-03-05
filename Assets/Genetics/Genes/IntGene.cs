using System;

namespace Genetics.Genes {

    [Serializable]
    public class IntGene : Gene<int> {

        [UnityEngine.SerializeField]
        int mutationMinimum;
        [UnityEngine.SerializeField]
        int mutationMaximum;

        public IntGene(string _name, int _value) : this(_name, _value, Zygosity.Homozygous, Dominance.Dominant, 0f) { }
        public IntGene(string _name, int _value, Zygosity _zygosity, Dominance _dominance, float _mutationProbability) : base(_name, _value, _zygosity, _dominance, _mutationProbability) {
            OnMutationSucceeded += IntGene_OnMutationSucceeded;
        }

        private void IntGene_OnMutationSucceeded() {
            Value = (int)(Random.NextDouble() * (mutationMaximum - mutationMinimum) + mutationMinimum);
        }

    }

}

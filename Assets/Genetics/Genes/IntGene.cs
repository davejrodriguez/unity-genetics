using System;

namespace Genetics.Genes {

    [Serializable]
    public class IntGene : Gene<int> {

        [UnityEngine.SerializeField]
        int mutationMinimum;
        [UnityEngine.SerializeField]
        int mutationMaximum;

        public IntGene(int _value) : this(_value, Dominance.Dominant, 0f) { }
        public IntGene(int _value, Dominance _dominance) : this(_value, _dominance, 0f) { }
        public IntGene(int _value, Dominance _dominance, float _mutationProbability) : base(_value, _dominance, _mutationProbability) {
            OnMutationSucceeded += IntGene_OnMutationSucceeded;
        }

        private void IntGene_OnMutationSucceeded() {
            Value = (int)(Random.NextDouble() * (mutationMaximum - mutationMinimum) + mutationMinimum);
        }

    }

}

using System;

namespace Genetics.Genes {

    [Serializable]
    public class FloatGene : Gene<float> {

        [UnityEngine.SerializeField]
        float mutationMinimum;
        [UnityEngine.SerializeField]
        float mutationMaximum;

        public FloatGene(float _value) : this(_value, Dominance.Dominant, 0f) { }
        public FloatGene(float _value, Dominance _dominance) : this(_value, _dominance, 0f) { }
        public FloatGene(float _value, Dominance _dominance, float _mutationProbability) : base(_value, _dominance, _mutationProbability) {
            OnMutationSucceeded += FloatGene_OnMutationSucceeded;
        }

        private void FloatGene_OnMutationSucceeded() {
            Value = (float)(Random.NextDouble() * (mutationMaximum - mutationMinimum) + mutationMinimum);
        }

    }

}

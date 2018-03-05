using System;
using UnityEditor;

namespace Genetics.Genes {

    [Serializable]
    public class FloatGene : Gene<float> {

        [UnityEngine.SerializeField]
        float mutationMinimum;
        [UnityEngine.SerializeField]
        float mutationMaximum;

        public FloatGene(string _name, float _value) : this(_name, _value, Zygosity.Homozygous, Dominance.Dominant, 0f) { }
        public FloatGene(string _name, float _value, Zygosity _zygosity, Dominance _dominance, float _mutationProbability) : base(_name, _value, _zygosity, _dominance, _mutationProbability) {
            OnMutationSucceeded += FloatGene_OnMutationSucceeded;
        }

        private void FloatGene_OnMutationSucceeded() {
            Value = (float)(Random.NextDouble() * (mutationMaximum - mutationMinimum) + mutationMinimum);
        }

        public override void OnGUI() {
            base.OnGUI();
            Value = EditorGUILayout.FloatField(Value);
            EditorGUILayout.MinMaxSlider(ref mutationMinimum, ref mutationMaximum, 0, 1000);
        }

    }

}

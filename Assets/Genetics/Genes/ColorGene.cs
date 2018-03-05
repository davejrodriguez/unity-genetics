using UnityEngine;
using System;

namespace Genetics.Genes {

    [Serializable]
    public class ColorGene : Gene<Color> {

        [SerializeField]
        Gradient mutationTolerance;

        public ColorGene(string _name, Color _color) : this(_name, _color, Zygosity.Homozygous, Dominance.Dominant, 0f) { }
        public ColorGene(string _name, Color _color, Zygosity _zygosity, Dominance _dominance, float _mutationProbability) : base(_name, _color, _zygosity, _dominance, _mutationProbability) {
            OnMutationSucceeded += ColorGene_OnMutationSucceeded;
        }

        private void ColorGene_OnMutationSucceeded() {
            Value = mutationTolerance.Evaluate((float)Random.NextDouble());
        }

    }

}

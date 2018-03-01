using UnityEngine;
using System;

namespace Genetics.Genes {

    [Serializable]
    public class ColorGene : Gene<Color> {

        [SerializeField]
        Gradient mutationTolerance;

        public ColorGene(Color _color) : this(_color, Dominance.Dominant, 0f) { }
        public ColorGene(Color _color, Dominance _dominance) : this(_color, _dominance, 0f) { }
        public ColorGene(Color _color, Dominance _dominance, float _mutationProbability) : base(_color, _dominance, _mutationProbability) {
            OnMutationSucceeded += ColorGene_OnMutationSucceeded;
        }

        private void ColorGene_OnMutationSucceeded() {
            Value = mutationTolerance.Evaluate((float)Random.NextDouble());
        }

    }

}

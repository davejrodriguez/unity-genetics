using UnityEngine;
using System;

namespace Genetics.Genes {

    [Serializable]
    public class Gene : ScriptableObject, IMutatable {

        [SerializeField]
        string _name;
        public virtual string Name { get { return _name; } protected set { _name = value + (int)Dominance; } } //the name of this gene
        [SerializeField]
        Dominance dominance;
        public virtual Dominance Dominance { get { return Dominance; } protected set { dominance = value; } } //the dominance of this gene (dominant or recessive)
        [Range(0f, 1f)]
        [SerializeField]
        float mutationProbability;
        public virtual float MutationProbability { get; set; } //the probability that this gene will mutate
        public virtual System.Random Random { get; set; } //a random number generator for probabilities

        public event Mutated OnMutationSucceeded;
        public event Mutated OnMutationFailed;

        public Gene(Dominance dominance, float mutationProbability) {
            Random = new System.Random();
            Dominance = dominance;
            MutationProbability = mutationProbability;
        }

        public virtual bool Mutate() {
            if ((float)Random.NextDouble() < MutationProbability) {
                if (OnMutationSucceeded != null) {
                    OnMutationSucceeded();
                }
                return true;
            } else {
                if (OnMutationFailed != null) {
                    OnMutationFailed();
                }
                return false;
            }
        }

    }

    [Serializable]
    public class Gene<T> : Gene {

        [SerializeField]
        T val;
        public virtual T Value { get { return val; } protected set { val = value; } } //the value of this gene

        public Gene(T value, Dominance dominance, float mutationProbability) : base(dominance, mutationProbability) {
            Value = value;
        }

    }

}
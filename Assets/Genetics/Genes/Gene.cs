using System;

namespace Genetics.Genes {

    [Serializable]
    public class Gene : IMutatable {

        [UnityEngine.SerializeField]
        string name;
        public virtual string Name { get { return name; } protected set { name = value + (int)Dominance; } } //the name of this gene
        [UnityEngine.SerializeField]
        Dominance dominance;
        public virtual Dominance Dominance { get { return Dominance; } protected set { dominance = value; } } //the dominance of this gene (dominant or recessive)
        [UnityEngine.Range(0f, 1f)]
        [UnityEngine.SerializeField]
        float mutationProbability;
        public virtual float MutationProbability { get; set; } //the probability that this gene will mutate
        public virtual Random Random { get; set; } //a random number generator for probabilities

        public event Mutated OnMutationSucceeded;
        public event Mutated OnMutationFailed;

        public Gene(Dominance dominance, float mutationProbability) {
            Random = new Random();
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
    public class Gene<T> : Gene{

        [UnityEngine.SerializeField]
        T val;
        public virtual T Value { get { return val; } protected set { val = value; } } //the value of this gene

        public Gene(T value, Dominance dominance, float mutationProbability) : base(dominance,mutationProbability) {
            Value = value;
        }

    }

}
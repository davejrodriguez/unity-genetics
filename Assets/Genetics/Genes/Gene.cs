using UnityEngine;
using System;
using UnityEditor;

namespace Genetics.Genes {

    [Serializable]
    public class Gene : ScriptableObject, IMutatable {

        public virtual string Name { get; protected set; } //the name of this gene
        public virtual object Value { get; protected set; }//the value of this gene
        public virtual Zygosity Zygosity { get; protected set; } //the zygosity of this gene (heterozygous, homozygous, hemizygous)
        public virtual Dominance Dominance { get; protected set; } //the dominance of this gene (dominant or recessive)
        public virtual float MutationProbability { get; set; } //the probability that this gene will mutate

        protected virtual System.Random Random { get; set; } //a random number generator for probabilities

        public event Mutated OnMutationSucceeded;
        public event Mutated OnMutationFailed;

        public void OnEnable() { hideFlags = HideFlags.HideAndDontSave; }

        public Gene(string name, object value, Zygosity zygosity, Dominance dominance, float mutationProbability) {

            Name = name;
            Value = value;
            Zygosity = zygosity;
            Dominance = dominance;
            MutationProbability = mutationProbability;
            Random = new System.Random();
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

        public virtual void OnGUI() {
            Name = EditorGUILayout.TextField(Name);
            Value = EditorGUILayout.ObjectField((UnityEngine.Object)Value, typeof(object), false);
            Zygosity = (Zygosity)EditorGUILayout.EnumPopup(Zygosity);
            Dominance = (Dominance)EditorGUILayout.EnumPopup(Dominance);
            MutationProbability = EditorGUILayout.Slider(MutationProbability, 0f, 1f);
        }

    }

    [Serializable]
    public class Gene<T> : Gene {

        public virtual new T Value { get; protected set; } //the value of this gene
        public virtual Allele<T> Allele { get; protected set; }

        public Gene(string name, T value, Zygosity zygosity, Dominance dominance, float mutationProbability) : base(name, value, zygosity, dominance, mutationProbability) {
            Value = value;
            Allele = CreateInstance<Allele<T>>();
            switch (zygosity) {
                case Zygosity.Heterozygous: Allele = new Allele<T>(name, value, zygosity, (Dominance)Mathf.Abs((int)dominance - 1), mutationProbability); break;
                case Zygosity.Homozygous: Allele = new Allele<T>(name, value, zygosity, dominance, mutationProbability); break;
                default: break;
            }
        }

    }

}
using UnityEngine;
using System.Collections.Generic;
using Genetics.Genes;

[System.Serializable]
public class Chromosome : ScriptableObject {

    [SerializeField]
    string name;
    public string Name {
        get {
            return name;
        }

        set {
            name = value;
        }
    }
    [SerializeField]
    List<Gene> Genes;
    //Gene[] genes;
    //public Gene[] Genes {
    //    get {
    //        return genes;
    //    }
    //    private set {
    //        genes = value;
    //    }
    //}
    Dictionary<string,Gene> geneDict;

    public void OnEnable() {
        if (Genes == null)
            Genes = new List<Gene>();

        hideFlags = HideFlags.HideAndDontSave;
    }

    public Chromosome(string _name) : this(_name, new List<Gene>()) { }
    public Chromosome(string _name,List<Gene> _genes) {
        Name = _name;
        Genes = _genes;
        geneDict = new Dictionary<string, Gene>();
    }

    public void Add(Gene _gene) {
        if(geneDict.ContainsKey(_gene.Name))
        geneDict.Add(_gene.Name,_gene);
    }

    public void Remove(Gene _gene) {

    }

    public void OnGUI() {
        foreach (var gene in Genes)
            gene.OnGUI();

        if (GUILayout.Button("Add Base"))
            Genes.Add(CreateInstance<Gene>());
        if (GUILayout.Button("Add Child"))
            Genes.Add(CreateInstance<FloatGene>());
    }

}

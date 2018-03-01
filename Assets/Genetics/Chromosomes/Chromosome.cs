using UnityEngine;
using System.Collections.Generic;
using Genetics.Genes;

[System.Serializable]
public class Chromosome {

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
    Gene[] genes;
    public Gene[] Genes {
        get {
            return genes;
        }
        private set {
            genes = value;
        }
    }
    Dictionary<string,Gene> geneDict;

    public Chromosome(string _name) : this(_name,new Gene[0]) { }
    public Chromosome(string _name,Gene[] _genes) {
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

}

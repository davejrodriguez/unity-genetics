using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewOrganism.asset", menuName = "Genetics/Organism", order = 0)]
public class Organism : ScriptableObject {

    [SerializeField]
    public List<Chromosome> chromosomes;

    void OnGUI() {
        foreach(Chromosome chromosome in chromosomes) {
            chromosome.OnGUI();
        }
    }

}

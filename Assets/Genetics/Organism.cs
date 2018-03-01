using UnityEngine;

[CreateAssetMenu(fileName = "NewOrganism.asset", menuName = "Genetics/New Organism", order = 0)]
public class Organism : ScriptableObject {

    public Chromosome[] chromosomes;

}

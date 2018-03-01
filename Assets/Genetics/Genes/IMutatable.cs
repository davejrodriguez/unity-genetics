namespace Genetics.Genes {

    public delegate void Mutated();

    public interface IMutatable {

        event Mutated OnMutationSucceeded;
        float MutationProbability { get; set; }
        bool Mutate();

    }

}

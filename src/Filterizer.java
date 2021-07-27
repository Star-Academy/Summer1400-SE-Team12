import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;

    public Filterizer(InvertedIndexMaker invertedIndex) {
        this.plusFilter = new PlusFilter(invertedIndex);
        this.minusFilter = new MinusFilter(invertedIndex);
        this.withOutSignFilter = new WithoutSignFilter(invertedIndex);
    }

    public Set<String> filter(QueryKeeper inputs, Set<String> preAnswers){
        Set<String> plusFiltered = plusFilter.filter(inputs.getPlusContain(), preAnswers);
        Set<String> withoutSignFiltered = withOutSignFilter.filter(
                inputs.getWithOutSign(), plusFiltered);
        Set<String> minusFiltered = minusFilter.filter(
                inputs.getMinusContain(), withoutSignFiltered);
        return minusFiltered;
    }



}

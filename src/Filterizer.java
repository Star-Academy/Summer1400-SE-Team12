import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;

    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter, WithoutSignFilter withOutSignFilter) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
    }


    public Set<String> filter(QueryKeeper queryKeeper, Set<String> preAnswers){
        Set<String> plusFiltered = plusFilter.filter(queryKeeper.getPlusContain(), preAnswers);
        Set<String> withoutSignFiltered = withOutSignFilter.filter(
                queryKeeper.getWithOutSign(), plusFiltered);
        Set<String> minusFiltered = minusFilter.filter(
                queryKeeper.getMinusContain(), withoutSignFiltered);
        return minusFiltered;
    }



}

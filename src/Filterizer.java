import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;
    private final Set<String> documentsName;

    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter,
                      WithoutSignFilter withOutSignFilter, Set<String> documentsName) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
        this.documentsName = documentsName;
    }


    public Set<String> filter(QueryKeeper queryKeeper){
        Set<String> plusFiltered = plusFilter.filter(queryKeeper.getPlusContain(), new HashSet<>());
        Set<String> withoutSignFiltered = withOutSignFilter.filter(
                queryKeeper.getWithOutSign(), documentsName);
        Set<String> minusFiltered = minusFilter.filter(
                queryKeeper.getMinusContain(), documentsName);

        withoutSignFiltered.retainAll(plusFiltered);
        minusFiltered.retainAll(withoutSignFiltered);
        return minusFiltered;
    }



}

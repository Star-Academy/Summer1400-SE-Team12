import java.util.HashSet;
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
        Set<String> plusFiltered = new HashSet<>(documentsName);
        Set<String> withoutSignFiltered = new HashSet<>(documentsName);
        Set<String> minusFiltered = new HashSet<>(documentsName);

        if(!queryKeeper.getPlusContain().isEmpty())
            plusFiltered = plusFilter.filter(queryKeeper.getPlusContain(), new HashSet<>());
        if(!queryKeeper.getWithOutSign().isEmpty())
            withoutSignFiltered = withOutSignFilter.filter(queryKeeper.getWithOutSign(), new HashSet<>());
        if(!queryKeeper.getMinusContain().isEmpty())
            minusFiltered = minusFilter.filter(queryKeeper.getMinusContain(), documentsName);

        return subscribeFiltered(plusFiltered, withoutSignFiltered, minusFiltered);
    }

    private Set<String> subscribeFiltered(Set<String>... filtered){
        Set<String> subscriptionResult = new HashSet<>(documentsName);
        for(Set<String> filteredType : filtered)
            subscriptionResult.retainAll(filteredType);
        return subscriptionResult;
    }


}

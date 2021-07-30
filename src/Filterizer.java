import java.util.HashSet;
import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;
    private final InvertedIndex invertedIndex;

    private final Set<String> answers;

    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter, WithoutSignFilter withOutSignFilter,
                      InvertedIndex invertedIndex, Set<String> documentsName) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
        this.invertedIndex = invertedIndex;
        this.answers = documentsName;
    }

    public void filterDocuments(QueryKeeper queryKeeper){
    for(String plusQuery : queryKeeper.getPlusContain())
        plusFilter.filter(invertedIndex.getInvertedIndexValue(plusQuery),new HashSet<>());
    for (String withoutSignQuery : queryKeeper.getWithOutSign())
        withOutSignFilter.filter(invertedIndex.getInvertedIndexValue(withoutSignQuery),answers);
    for (String minusQuery : queryKeeper.getMinusContain())
        minusFilter.filter(invertedIndex.getInvertedIndexValue(minusQuery),answers);
    }

    public Set<String> getAnswers() {
        return answers;
    }

}

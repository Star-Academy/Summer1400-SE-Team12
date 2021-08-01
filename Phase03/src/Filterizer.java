package Phase02;

import java.util.HashSet;
import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;
    private final InvertedIndex invertedIndex;


    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter, WithoutSignFilter withOutSignFilter,
                      InvertedIndex invertedIndex) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
        this.invertedIndex = invertedIndex;
    }

    public Set<String> filterDocuments(QueryKeeper queryKeeper ,Set<String> answersDocumentsName) {
        boolean firstIterationFlag = true;
        for (String plusQuery : queryKeeper.getPlusContain()) {
            if (firstIterationFlag) {
                answersDocumentsName = new HashSet<>();
                firstIterationFlag = false;
            }
            plusFilter.filter(invertedIndex.getInvertedIndexValue(plusQuery), answersDocumentsName);
        }
        for (String withoutSignQuery : queryKeeper.getWithOutSign())
            withOutSignFilter.filter(invertedIndex.getInvertedIndexValue(withoutSignQuery), answersDocumentsName);
        for (String minusQuery : queryKeeper.getMinusContain())
            minusFilter.filter(invertedIndex.getInvertedIndexValue(minusQuery), answersDocumentsName);
        return answersDocumentsName;
    }


}

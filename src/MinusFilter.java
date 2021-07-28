import java.util.HashSet;
import java.util.Set;

public class MinusFilter extends Filter {


    public MinusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> minusCategorized, Set<String> documentsName) {
        Set<String> minusFiltered = new HashSet<>(documentsName);
        for (String minusCat : minusCategorized) {
            if (invertedIndex.containsInvertedIndexKey(minusCat))
                minusFiltered.removeAll(invertedIndex.getInvertedIndexValue(minusCat));
        }

        return minusFiltered;
    }
}

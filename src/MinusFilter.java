import java.util.HashSet;
import java.util.Set;

public class MinusFilter extends Filter{


    public MinusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> minusCategorized, Set<String> withOutSignFiltered) {
        Set<String> minusFiltered = new HashSet<>(withOutSignFiltered);
        for (String minusCat : minusCategorized) {
            String pureWord = minusCat.substring(1);
            if (invertedIndex.containsInvertedIndexKey(pureWord))
                minusFiltered.removeAll(invertedIndex.getInvertedIndexValue(pureWord));
        }

        return minusFiltered;
    }
}

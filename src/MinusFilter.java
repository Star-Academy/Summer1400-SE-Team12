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
            if (invertedIndex.containsKey(pureWord))
                minusFiltered.removeAll(invertedIndex.getValue(pureWord));
        }
        //Set<String> minusFiltered = withOutSignFiltered;

        return minusFiltered;
    }
}

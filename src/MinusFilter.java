import java.util.Set;

public class MinusFilter {
    private final InvertedIndexMaker invertedIndexMaker;

    public MinusFilter(InvertedIndexMaker invertedIndexMaker) {

        this.invertedIndexMaker = invertedIndexMaker;
    }

    public Set<String> filterWithMinus(Set<String> minusCategorized, Set<String> withOutSignFiltered) {

        for (String minus : minusCategorized) {
            String pureWord = minus.substring(1);
            if (invertedIndexMaker.invertedIndex.containsKey(pureWord))
                withOutSignFiltered.removeAll(invertedIndexMaker.invertedIndex.get(pureWord));
        }
        Set<String> minusFiltered = withOutSignFiltered;

        return minusFiltered;
    }
}

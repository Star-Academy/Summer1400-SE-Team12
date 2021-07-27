import java.util.Set;

public class MinusFilter extends Filter{


    public MinusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> minusCategorized, Set<String> withOutSignFiltered) {

        for (String minus : minusCategorized) {
            String pureWord = minus.substring(1);
            if (invertedIndex.containsKey(pureWord))
                withOutSignFiltered.removeAll(invertedIndex.getValue(pureWord));
        }
        //Set<String> minusFiltered = withOutSignFiltered;

        return withOutSignFiltered;
    }
}

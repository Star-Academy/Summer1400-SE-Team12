import java.util.HashSet;
import java.util.Set;

public class PlusFilter {
    private final InvertedIndexMaker invertedIndexMaker;

    public PlusFilter(InvertedIndexMaker invertedIndexMaker) {

        this.invertedIndexMaker = invertedIndexMaker;
    }

    public Set<String> filterWithPlus(Set<String> plusCategorized) {
        Set<String> plusFiltered = new HashSet<>();
        for (String plus : plusCategorized) {
            String pureWord = plus.substring(1);
            if (invertedIndexMaker.invertedIndex.containsKey(pureWord))
                plusFiltered.addAll(invertedIndexMaker.invertedIndex.get(pureWord));
        }
        return plusFiltered;
    }


}

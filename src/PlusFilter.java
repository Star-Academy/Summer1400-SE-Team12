import java.util.HashSet;
import java.util.Set;

public class PlusFilter extends Filter{


    public PlusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    @Override
    public Set<String> filter(Set<String> plusCategorized, Set<String> previousFiltered) {
        Set<String> plusFiltered = new HashSet<>(previousFiltered);
        for (String plus : plusCategorized) {
            String pureWord = plus.substring(1);
            if (invertedIndex.containsKey(pureWord))
                plusFiltered.addAll(invertedIndex.getValue(pureWord));
        }
        return plusFiltered;
    }



}

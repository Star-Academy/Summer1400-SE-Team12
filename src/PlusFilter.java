import java.util.HashSet;
import java.util.Set;

public class PlusFilter extends Filter{


    public PlusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    @Override
    public Set<String> filter(Set<String> plusCategorized, Set<String> preFiltered) {
        for (String plus : plusCategorized) {
            String pureWord = plus.substring(1);
            if (invertedIndex.containsKey(pureWord))
                preFiltered.addAll(invertedIndex.getValue(pureWord));
        }
        return preFiltered;
    }



}

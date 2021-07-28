import java.util.HashSet;
import java.util.Set;

public class PlusFilter extends Filter{

    public PlusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    @Override
    public Set<String> filter(Set<String> plusCategorized, Set<String>emptySet) {
        Set<String> plusFiltered = new HashSet<>();
        for (String plusCat : plusCategorized) {
            if (invertedIndex.containsInvertedIndexKey(plusCat))
                plusFiltered.addAll(invertedIndex.getInvertedIndexValue(plusCat));
        }
        return plusFiltered;
    }



}

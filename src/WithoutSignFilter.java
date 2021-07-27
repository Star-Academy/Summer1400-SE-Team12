import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilter extends Filter {


    public WithoutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> plusFiltered) {
        Set<String> withoutSignFiltered = new HashSet<>(plusFiltered);
        for (String withoutSignCat : withOutSignCategorized) {
            if (invertedIndex.containsInvertedIndexKey(withoutSignCat)) {
                if (withoutSignFiltered.isEmpty())
                    withoutSignFiltered.addAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                else {
                    withoutSignFiltered.retainAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                }
            } else {
                withoutSignFiltered.clear();
                break;
            }
        }

        return withoutSignFiltered;
    }
}

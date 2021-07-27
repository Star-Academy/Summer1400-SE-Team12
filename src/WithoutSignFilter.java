import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilter extends Filter {


    public WithoutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> documentsName) {
        Set<String> withoutSignFilter = new HashSet<>();
        for (String withoutSignCat : withOutSignCategorized) {
            if (invertedIndex.containsInvertedIndexKey(withoutSignCat)) {
                if (withoutSignFilter.isEmpty())
                    withoutSignFilter.addAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                else {
                    withoutSignFilter.retainAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                }
            } else {
                withoutSignFilter.clear();
                break;
            }
        }

        return withoutSignFilter;
    }
}

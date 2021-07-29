package Phase2;

import Phase2.Filter;
import Phase2.InvertedIndexMaker;

import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilter extends Filter {


    public WithoutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> emptySet) {
        Set<String> withoutSignFilter = new HashSet<>();
        for (String withoutSignCat : withOutSignCategorized) {
            if (invertedIndex.invertedIndex.containsKey(withoutSignCat)) {
                if (withoutSignFilter.isEmpty())
                    withoutSignFilter.addAll(invertedIndex.invertedIndex.get(withoutSignCat));
                else {
                    withoutSignFilter.retainAll(invertedIndex.invertedIndex.get(withoutSignCat));
                }
            } else {
                withoutSignFilter.clear();
                break;
            }
        }

        return withoutSignFilter;
    }
}

import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilter extends Filter {


    public WithoutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> plusFiltered) {
        Set<String> withoutSignFiltered = new HashSet<>(plusFiltered);
        for (String withoutSignCat : withOutSignCategorized) {
            if (invertedIndex.containsKey(withoutSignCat)) {
                if (withoutSignFiltered.isEmpty())
                    withoutSignFiltered.addAll(invertedIndex.getValue(withoutSignCat));
                else {
                    withoutSignFiltered.retainAll(invertedIndex.getValue(withoutSignCat));
                }
            } else {
                withoutSignFiltered.clear();
                break;
            }
        }
        //Set<String> withOutSignFilter = plusFiltered;
        return withoutSignFiltered;
    }
}

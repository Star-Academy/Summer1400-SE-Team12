import java.util.Set;

public class WithOutSignFilter extends Filter {


    public WithOutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> plusFiltered) {
        for (String n : withOutSignCategorized) {
            if (invertedIndex.containsKey(n)) {
                if (plusFiltered.size() == 0)
                    plusFiltered.addAll(invertedIndex.getValue(n));
                else {
                    plusFiltered.retainAll(invertedIndex.getValue(n));
                }
            } else {
                plusFiltered.clear();
                break;
            }
        }
        //Set<String> withOutSignFilter = plusFiltered;
        return plusFiltered;
    }
}

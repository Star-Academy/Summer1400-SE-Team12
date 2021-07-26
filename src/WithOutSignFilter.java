import java.util.Set;

public class WithOutSignFilter {
    private final InvertedIndexMaker invertedIndexMaker;

    public WithOutSignFilter(InvertedIndexMaker invertedIndexMaker) {

        this.invertedIndexMaker = invertedIndexMaker;
    }


    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> plusFiltered) {
        for (String n : withOutSignCategorized) {
            if (invertedIndexMaker.invertedIndex.containsKey(n)) {
                if (plusFiltered.size() == 0)
                    plusFiltered.addAll(invertedIndexMaker.invertedIndex.get(n));
                else {
                    plusFiltered.retainAll(invertedIndexMaker.invertedIndex.get(n));
                }
            } else {
                plusFiltered.clear();
                break;
            }
        }
        Set<String> withOutSignFilter = plusFiltered;
        return withOutSignFilter;
    }
}

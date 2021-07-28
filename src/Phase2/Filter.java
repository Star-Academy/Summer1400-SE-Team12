package Phase2;

import java.util.Set;

public abstract class Filter {
    protected final InvertedIndexMaker invertedIndex;

    public Filter(InvertedIndexMaker invertedIndexMaker) {

        this.invertedIndex = invertedIndexMaker;
    }

    public abstract Set<String> filter(Set<String> signCategorized, Set<String> previousFiltered);
}

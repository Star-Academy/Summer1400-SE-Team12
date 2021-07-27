import java.util.HashSet;
import java.util.Set;

public class MinusFilter extends Filter{


    public MinusFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> minusCategorized, Set<String> documentsName) {
        for (String minusCat : minusCategorized) {
            String pureWord = minusCat.substring(1);
            if (invertedIndex.containsInvertedIndexKey(pureWord))
                documentsName.removeAll(invertedIndex.getInvertedIndexValue(pureWord));
        }

        return documentsName;
    }
}

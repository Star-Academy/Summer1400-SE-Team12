import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilter extends Filter {


    public WithoutSignFilter(InvertedIndexMaker invertedIndexMaker) {
        super(invertedIndexMaker);
    }

    public Set<String> filter(Set<String> withOutSignCategorized, Set<String> documentsName) {
        for (String withoutSignCat : withOutSignCategorized) {
            if (invertedIndex.containsInvertedIndexKey(withoutSignCat)) {
                if (documentsName.isEmpty())
                    documentsName.addAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                else {
                    documentsName.retainAll(invertedIndex.getInvertedIndexValue(withoutSignCat));
                }
            } else {
                documentsName.clear();
                break;
            }
        }

        return documentsName;
    }
}

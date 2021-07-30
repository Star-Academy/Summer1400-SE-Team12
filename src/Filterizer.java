import java.util.HashSet;
import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithoutSignFilter withOutSignFilter;
    private final InvertedIndex invertedIndex;
    private final Set<String> answers;

    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter, WithoutSignFilter withOutSignFilter,
                      InvertedIndex invertedIndex, Set<String> documentsName) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
        this.invertedIndex = invertedIndex;
        this.answers = documentsName;
    }

    public Set<String> filter(QueryKeeper queryKeeper){
    return answers;
    }




}

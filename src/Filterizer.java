import java.util.Set;

public class Filterizer {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithOutSignFilter withOutSignFilter;

    public Filterizer(PlusFilter plusFilter, MinusFilter minusFilter,
                      WithOutSignFilter withOutSignFilter) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
    }

    public Set<String> filter(InputReader inputs, Set<String> preAnswers){
        Set<String> plusFiltered = plusFilter.filter(inputs.getPlusContain(), preAnswers);
        Set<String> withoutSignFiltered = withOutSignFilter.filter(
                inputs.getWithOutSign(), plusFiltered);
        Set<String> minusFiltered = minusFilter.filter(
                inputs.getMinusContain(), withoutSignFiltered);
        return minusFiltered;
    }

    public void printFilteredAnswers(Set<String> answers){
        if (answers.size() == 0) {
            System.out.println("We didn't find");
        } else {
            System.out.println(answers.toString());
        }
    }

}

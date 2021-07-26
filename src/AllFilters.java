import java.util.Set;

public class AllFilters {
    private final PlusFilter plusFilter;
    private final MinusFilter minusFilter;
    private final WithOutSignFilter withOutSignFilter;

    public AllFilters(PlusFilter plusFilter, MinusFilter minusFilter,
                      WithOutSignFilter withOutSignFilter) {
        this.plusFilter = plusFilter;
        this.minusFilter = minusFilter;
        this.withOutSignFilter = withOutSignFilter;
    }

    public Set<String> filter(InputReader inputs){
        Set<String> plusFiltered = plusFilter.filterWithPlus(inputs.getPlusContain());
        Set<String> withoutSignFiltered = withOutSignFilter.filter(
                inputs.getWithOutSign(), plusFiltered);
        Set<String> minusFiltered = minusFilter.filterWithMinus(
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

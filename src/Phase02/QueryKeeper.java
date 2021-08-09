package Phase02;

import java.util.HashSet;
import java.util.Set;

public class QueryKeeper {
    private final Set<String> plusContain;
    private final Set<String> minusContain;
    private final Set<String> withOutSign;

    public QueryKeeper(Set<String> plusContain, Set<String> minusContain, Set<String> withOutSign) {
        this.plusContain = plusContain;
        this.minusContain = minusContain;
        this.withOutSign = withOutSign;
    }

    public Set<String> getPlusContain() {
        return plusContain;
    }

    public Set<String> getMinusContain() {
        return minusContain;
    }

    public Set<String> getWithOutSign() {
        return withOutSign;
    }


}

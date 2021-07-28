package Phase2;

import java.util.HashSet;
import java.util.Set;

public class QueryKeeper {
    private final Set<String> plusContain = new HashSet<>();
    private final Set<String> minusContain = new HashSet<>();
    private final Set<String> withOutSign = new HashSet<>();

    public Set<String> getPlusContain() {
        return plusContain;
    }

    public Set<String> getMinusContain() {
        return minusContain;
    }

    public Set<String> getWithOutSign() {
        return withOutSign;
    }

    public void addPlusContain(String plusQuery) {
        plusContain.add(plusQuery);
    }

    public void addMinusContain(String minusQuery) {
        minusContain.add(minusQuery);
    }

    public void addWithoutSignContain(String withoutSignQuery) {
        withOutSign.add(withoutSignQuery);
    }
}

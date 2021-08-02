package Phase02;

import java.util.Set;

public class MinusFilter implements Filter {

    @Override
    public void filter(Set<String> documentsContainMinusQuery, Set<String> preFiltered) {
        preFiltered.removeAll(documentsContainMinusQuery);
    }
}

package Phase02;

import java.util.Set;

public class WithoutSignFilter implements Filter {

    @Override
    public void filter(Set<String> documentsContainWithoutSignQuery, Set<String> preFiltered) {
        preFiltered.retainAll(documentsContainWithoutSignQuery);
    }
}

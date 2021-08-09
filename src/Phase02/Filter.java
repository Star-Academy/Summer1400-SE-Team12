package Phase02;

import java.util.Set;

public interface Filter {
    void filter(Set<String> documentsContainSignQuery, Set<String> previousFiltered);
}

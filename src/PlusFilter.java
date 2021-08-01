import java.util.Set;

public class PlusFilter implements Filter {

    @Override
    public void filter(Set<String> documentsContainPlusQuery, Set<String> preFiltered) {
        preFiltered.addAll(documentsContainPlusQuery);
    }
}

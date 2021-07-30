import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class QueryCategorizer {
    private final QueryKeeper queryKeeper = new QueryKeeper();

    public void categorizeQuery() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please enter a query");
        String query = scanner.nextLine();
        separateBySign(query.toLowerCase().split(" "));
    }

    private void separateBySign(String[] query) {
        Set<String> plusContain = new HashSet<>();
        Set<String> minusContain = new HashSet<>();
        Set<String> withoutContain = new HashSet<>();

        for (String queryIterator : query) {
            if (queryIterator.contains("+")) {
                plusContain.add(queryIterator.substring(1));
            } else if (queryIterator.contains("-")) {
                minusContain.add(queryIterator.substring(1));
            } else {
                withoutContain.add(queryIterator);
            }
        }
        queryKeeper.addAllSets(plusContain,minusContain,withoutContain);

    }

    public QueryKeeper getQueryKeeper() {
        return queryKeeper;
    }

}

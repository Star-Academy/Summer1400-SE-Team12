package Phase2;

import Phase2.QueryKeeper;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class QueryCategorizer {
    private String query;

    private final QueryKeeper queryKeeper = new QueryKeeper();

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

    public void categorizeQuery() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please enter a query");
         query = scanner.nextLine();
        separateBySign(query.split(" "));
    }
    //String query global shode o getter gozashtam

    public QueryKeeper getQueryKeeper() {
        return queryKeeper;
    }
    public String getQuery() {
        return query;
    }
}



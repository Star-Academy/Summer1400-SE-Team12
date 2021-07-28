package Phase2;

import java.util.Scanner;

public class QueryCategorizer {
    private final QueryKeeper queryKeeper = new QueryKeeper();

    private void separateBySign(String[] query) {
        for (String queryIterator : query) {
            if (queryIterator.contains("+")) {
                queryKeeper.addPlusContain(queryIterator.substring(1));
            } else if (queryIterator.contains("-")) {
                queryKeeper.addMinusContain(queryIterator.substring(1));
            } else {
                queryKeeper.addWithoutSignContain(queryIterator);
            }
        }
    }

    public void categorizeQuery() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please enter a query");
        String query = scanner.nextLine();
        separateBySign(query.split(" "));
    }

    public QueryKeeper getQueryKeeper() {
        return queryKeeper;
    }

}

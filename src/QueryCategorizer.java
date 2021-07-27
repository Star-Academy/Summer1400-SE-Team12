import java.util.Scanner;

public class QueryCategorizer {
    private final QueryKeeper queryKeeper = new QueryKeeper();

    private void separateBySign(String[] query) {
        for (String queryIterator : query) {
            if (queryIterator.contains("+")) {
                queryKeeper.getPlusContain().add(queryIterator.substring(1));
            } else if (queryIterator.contains("-")) {
                queryKeeper.getMinusContain().add(queryIterator.substring(1));
            } else {
                queryKeeper.getWithOutSign().add(queryIterator);
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

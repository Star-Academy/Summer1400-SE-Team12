import java.util.Scanner;

public class QueryCategorizer {
    private final QueryKeeper queryKeeper = new QueryKeeper();

    private void separateBySign(String[] query) {
        for (String queryIterator : query) {
            if (queryIterator.contains("+")) {
                queryKeeper.getPlusContain().add(queryIterator);
            } else if (queryIterator.contains("-")) {
                queryKeeper.getMinusContain().add(queryIterator);
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

}

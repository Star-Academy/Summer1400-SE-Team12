package Phase02;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class QueryCategorizer {


    public QueryKeeper categorizeQuery() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Please enter a query");
        String query = scanner.nextLine();
        return separateBySign(query.toLowerCase().split(" "));
    }

    private QueryKeeper separateBySign(String[] query) {
        Set<String> plusContain = new HashSet<>();
        Set<String> minusContain = new HashSet<>();
        Set<String> withoutContain = new HashSet<>();

        for (String queryIterator : query) {
            char firstChar  = queryIterator.charAt(0);
            switch (firstChar){
                case '+': plusContain.add(queryIterator.substring(1));
                    break;
                case '-': minusContain.add(queryIterator.substring(1));
                    break;
                default:  withoutContain.add(queryIterator);
            }
        }
        return new QueryKeeper(plusContain,minusContain,withoutContain);

    }


}

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class InputReader {
    private final Set<String> plusContain = new HashSet<>();
    private final Set<String> minusContain = new HashSet<>();
    private final Set<String> withOutSign = new HashSet<>();

    private void categorizeInput(String[] query) {
        for (String queryIterator : query) {
            if (queryIterator.contains("+")) {
                plusContain.add(queryIterator);
            } else if (queryIterator.contains("-")) {
                minusContain.add(queryIterator);
            } else {
                withOutSign.add(queryIterator);
            }
        }
    }

    public String readInput() {
        Scanner scanner = new Scanner(System.in);
        String pathOfTheFiles = scanner.nextLine();
        System.out.println("Please enter a query");
        String query = scanner.nextLine();
        categorizeInput(query.split(" "));
        return pathOfTheFiles;
    }

    public Set<String> getPlusContain() {
        return plusContain;
    }

    public Set<String> getMinusContain() {
        return minusContain;
    }

    public Set<String> getWithOutSign() {
        return withOutSign;
    }
}

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.*;

public class Phase01 {
    private static HashMap<String, List<String>> invertedIndex;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String path = sc.next();
        buildMap(path);
        System.out.println("please enter a query");

        Set<String> plusContain = new HashSet<>();
        Set<String> minusContain = new HashSet<>();
        Set<String> none = new HashSet<>();

        sc.nextLine();
        String[] query = sc.nextLine().split(" ");
        for (String q : query) {
            if (q.contains("+")) {
                plusContain.add(q);
            } else if (q.contains("-")) {
                minusContain.add(q);
            } else {
                none.add(q);
            }

        }

        Set<String> answers = new HashSet<>();

        for (String plus : plusContain) {
            String pureWord = plus.substring(1);
            if (invertedIndex.containsKey(pureWord))
                answers.addAll(invertedIndex.get(pureWord));
        }


        for (String n : none) {
            if (invertedIndex.containsKey(n)) {
                if (answers.size() == 0)
                    answers.addAll(invertedIndex.get(n));
                else
                    answers.retainAll(invertedIndex.get(n)); // question
            }
        }


        for (String minus : minusContain) {
            String pureWord = minus.substring(1);
            if (invertedIndex.containsKey(pureWord))
                answers.removeAll(invertedIndex.get(pureWord));
        }


        for (String ans : answers)
            System.out.println(ans);

    }

    public static Map documentReader(String path) {
        Map<String, String> document = new HashMap<>();
        try {
            File sourceFolder = new File(path);
            for (File sourceFile : sourceFolder.listFiles()) {
                String fileName = sourceFile.getName();
                document.put(fileName, Files.readString(Path.of(path + "\\" + fileName)));//open file
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
        return document;
    }

    private static void buildMap(String path) {
        invertedIndex = new HashMap<>();

        Map<String, String> document = documentReader(path);
        for (Map.Entry<String, String> doc : document.entrySet()) {
            String[] words = doc.getValue().split(" ");
            for (int j = 0; j < words.length; j++) {
                String lowercase = words[j].toLowerCase();
                if (invertedIndex.containsKey(lowercase))
                    invertedIndex.get(lowercase).add(doc.getKey());
                else {
                    ArrayList<String> documentIDs = new ArrayList<>();
                    documentIDs.add(doc.getKey());
                    invertedIndex.put(lowercase, documentIDs);
                }
            }
        }
    }
}

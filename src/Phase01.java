import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.*;

public class Phase01 {
    private static HashMap<String, List<String>> invertedIndex;

    public static void main(String[] args) throws IOException {
        //test
        //invertedIndex.get(pureWord)
        //dad mom sister +brother +baba -maman -mmd
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
        String backSlash = "\\";
        try {
            File sourceFolder = new File(path);
            String fileExt = "";
            for (File sourceFile : sourceFolder.listFiles()) {
                String fileName = sourceFile.getName();//baraye khondan esm
                fileExt = fileName.substring(fileName.lastIndexOf(".") + 1);
                if (fileExt.equalsIgnoreCase("txt")) {
                    System.out.println("khande shd " + fileName);
                    //Todo  biad khode txt bekhoone
                    document.put(fileName, Files.readString(Path.of(path + backSlash + fileName)));//open file
                } else {
                    System.out.println("txt nist " + fileName);
                }
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
            for (int j = 0; j < words.length; j++)
                if (invertedIndex.containsKey(words[j]))
                    invertedIndex.get(words[j]).add(doc.getKey());
                else {
                    ArrayList<String> documentIDs = new ArrayList<>();
                    documentIDs.add(doc.getKey());
                    invertedIndex.put(words[j], documentIDs);
                }

        }
    }
}

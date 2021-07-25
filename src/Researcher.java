import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Researcher {
    static HashMap<String, List<String>> invertedIndex;

    static void buildInvertedIndex(String path) {
        invertedIndex = new HashMap<>();

        Map<String, String> document = FileReader.readDocument(path);

        for (Map.Entry<String, String> doc : document.entrySet()) {
            String[] words = doc.getValue().split("[\\W]+");

            for (int j = 0; j < words.length; j++) {
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
}

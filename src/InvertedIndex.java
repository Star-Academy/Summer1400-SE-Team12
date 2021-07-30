import java.util.*;

public class InvertedIndex {

    private final HashMap<String, Set<String>> invertedIndex = new HashMap<>();

    public void buildInvertedIndex(Map<String, String> DocNameMapToContent) {
        for (Map.Entry<String, String> doc : DocNameMapToContent.entrySet()) {
            String[] words = splitDocumentsWords(doc.getValue());
            addDocumentWords(doc.getKey(), words);
        }
    }

    private String[] splitDocumentsWords(String docContent) {
        return docContent.split("[\\W]+");
    }

    private void addDocumentWords(String docName, String[] docWords) {
        for (String word : docWords) {
            if(invertedIndex.containsKey(word))
                invertedIndex.get(word).add(docName);
            else
                invertedIndex.put(word, new HashSet<>(Arrays.asList(docName)));
        }
    }

    public Set<String> getInvertedIndexValue(String key) {
        return invertedIndex.getOrDefault(key, new HashSet<>());
    }

}
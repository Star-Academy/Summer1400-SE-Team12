import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class InvertedIndexMaker {
    private final HashMap<String, List<String>> invertedIndex = new HashMap<>();
    private final FileReader fileReader;

    public InvertedIndexMaker(FileReader fileReader) {
        this.fileReader = fileReader;
    }

    public void buildInvertedIndex(Map<String, String[]> splitedDocumentInfo) {

        for (Map.Entry<String, String[]> doc : splitedDocumentInfo.entrySet()) {
            for (int j = 0; j < doc.getValue().length; j++) {
                if (invertedIndex.containsKey(doc.getValue()[j]))
                    invertedIndex.get(doc.getValue()[j]).add(doc.getKey());
                else {
                    ArrayList<String> documentNames = new ArrayList<>();
                    documentNames.add(doc.getKey());
                    invertedIndex.put(doc.getValue()[j], documentNames);
                }
            }
        }
    }

    public Map<String, String[]> wordSplitter(String pathOfTheDocument) {
        Map<String, String[]> splittedDocumentInfo = new HashMap<>();
        Map<String, String> document = fileReader.readDocument(pathOfTheDocument);
        for (Map.Entry<String, String> doc : document.entrySet())
            splittedDocumentInfo.put(doc.getKey(), doc.getValue().split("[\\W]+"));
        return splittedDocumentInfo;
    }

    public boolean containsKey(String key){
        return invertedIndex.containsKey(key);
    }

    public List<String> getValue(String key){
        return invertedIndex.get(key);
    }

}
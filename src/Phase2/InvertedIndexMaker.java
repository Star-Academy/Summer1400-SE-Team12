package Phase2;

import java.util.*;

class InvertedIndexMaker {
    private final HashMap<String, Set<String>> invertedIndex = new HashMap<>();
    private final FileReader fileReader;

    public InvertedIndexMaker(FileReader fileReader) {
        this.fileReader = fileReader;
    }

    public void buildInvertedIndex(Map<String, String[]> splittedDocumentInfo) {

        for (Map.Entry<String, String[]> doc : splittedDocumentInfo.entrySet()) {
            for (int j = 0; j < doc.getValue().length; j++) {
                if (invertedIndex.containsKey(doc.getValue()[j]))
                    invertedIndex.get(doc.getValue()[j]).add(doc.getKey());
                else {
                    Set<String> documentNames = new HashSet<>();
                    documentNames.add(doc.getKey());
                    invertedIndex.put(doc.getValue()[j], documentNames);
                }
            }
        }
    }

    public Map<String, String[]> splitDocumentsWords(String pathOfTheDocument) {
        Map<String, String[]> splittedDocumentInfo = new HashMap<>();
        Map<String, String> document = fileReader.readDocuments(pathOfTheDocument);
        for (Map.Entry<String, String> doc : document.entrySet())
            splittedDocumentInfo.put(doc.getKey(), doc.getValue().split("[\\W]+"));
        return splittedDocumentInfo;
    }

    public boolean containsInvertedIndexKey(String key){
        return invertedIndex.containsKey(key);
    }

    public Set<String> getInvertedIndexValue(String key){
        return invertedIndex.get(key);
    }

}
import java.util.*;

public class Main {


    final static String PATH_OF_THE_FILE = "src\\EnglishData";

    public static void main(String[] args) {
        FileReader fileReader = new FileReader();
        InvertedIndex invertedIndex = new InvertedIndex(fileReader);
        QueryCategorizer queryCategorizer = new QueryCategorizer();
        PlusFilter plusFilter = new PlusFilter();
        MinusFilter minusFilter = new MinusFilter();
        WithoutSignFilter withOutSignFilter = new WithoutSignFilter();


        Map<String, String[]> splitDocumentInfo = invertedIndex.splitDocumentsWords(PATH_OF_THE_FILE);
        queryCategorizer.categorizeQuery();
        Filterizer filterizer = new Filterizer(plusFilter, minusFilter, withOutSignFilter, invertedIndex,
                splitDocumentInfo.keySet());
        invertedIndex.buildInvertedIndex(splitDocumentInfo);
        filterizer.filterDocuments(queryCategorizer.getQueryKeeper());
        printFilteredAnswers(filterizer.getAnswers());
    }

    public static void printFilteredAnswers(Set<String> answers){
        if (answers.size() == 0) {
            System.out.println("We didn't find");
        } else {
            System.out.println(answers.toString());
        }
    }
}

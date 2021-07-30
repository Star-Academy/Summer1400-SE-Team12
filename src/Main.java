import java.util.*;

public class Main {


    final static String PATH_OF_THE_FILE = "src\\EnglishData";

    public static void main(String[] args) {
        QueryCategorizer queryCategorizer = new QueryCategorizer();
        FileReader fileReader = new FileReader();
        InvertedIndex invertedIndexMaker = new InvertedIndex(fileReader);
        PlusFilter plusFilter = new PlusFilter();
        MinusFilter minusFilter = new MinusFilter();
        WithoutSignFilter withOutSignFilter = new WithoutSignFilter();

        queryCategorizer.categorizeQuery();
        Map<String, String[]> splitDocumentInfo = invertedIndexMaker.splitDocumentsWords(PATH_OF_THE_FILE);
        Filterizer filterizer = new Filterizer();
        invertedIndexMaker.buildInvertedIndex(splitDocumentInfo);
        Set<String> answers = filterizer.filter(queryCategorizer.getQueryKeeper());
        printFilteredAnswers(answers);
    }

    public static void printFilteredAnswers(Set<String> answers){
        if (answers.size() == 0) {
            System.out.println("We didn't find");
        } else {
            System.out.println(answers.toString());
        }
    }
}

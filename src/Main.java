import java.util.*;

public class Main {
    final static String PATH_OF_THE_FILE = "EnglishData";

    public static void main(String[] args) {
        QueryCategorizer queryCategorizer = new QueryCategorizer();
        FileReader fileReader = new FileReader();
        InvertedIndexMaker invertedIndexMaker = new InvertedIndexMaker(fileReader);
        PlusFilter plusFilter = new PlusFilter(invertedIndexMaker);
        MinusFilter minusFilter = new MinusFilter(invertedIndexMaker);
        WithoutSignFilter withOutSignFilter = new WithoutSignFilter(invertedIndexMaker);
        Filterizer filterizer = new Filterizer(plusFilter, minusFilter, withOutSignFilter);

        queryCategorizer.categorizeQuery();
        Map<String, String[]> splitDocumentInfo = invertedIndexMaker.splitDocumentsWords(PATH_OF_THE_FILE);
        invertedIndexMaker.buildInvertedIndex(splitDocumentInfo);
        Set<String> answers = filterizer.filter(queryCategorizer.getQueryKeeper(), new HashSet<>());
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

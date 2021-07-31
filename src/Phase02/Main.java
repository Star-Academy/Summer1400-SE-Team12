package Phase02;

import java.util.*;

public class Main {


    final static String PATH_OF_THE_FILE = "src\\EnglishData";

    public static void main(String[] args) {
        FileReader fileReader = new FileReader();
        InvertedIndex invertedIndex = new InvertedIndex();
        QueryCategorizer queryCategorizer = new QueryCategorizer();
        PlusFilter plusFilter = new PlusFilter();
        MinusFilter minusFilter = new MinusFilter();
        WithoutSignFilter withOutSignFilter = new WithoutSignFilter();

        Map<String,String> docNameMapToContent = fileReader.readDocuments(PATH_OF_THE_FILE);
        invertedIndex.buildInvertedIndex(docNameMapToContent);
        queryCategorizer.categorizeQuery();
        Filterizer filterizer = new Filterizer(plusFilter, minusFilter, withOutSignFilter,
                invertedIndex, docNameMapToContent.keySet());
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

import java.util.*;

public class Main {

    public static void main(String[] args) {
        InputReader inputs = new InputReader();
        FileReader fileReader = new FileReader();
        InvertedIndexMaker invertedIndexMaker = new InvertedIndexMaker(fileReader);
        PlusFilter plusFilter = new PlusFilter(invertedIndexMaker);
        WithOutSignFilter withOutSignFilter = new WithOutSignFilter(invertedIndexMaker);
        MinusFilter minusFilter = new MinusFilter(invertedIndexMaker);
        Filterizer filterizer = new Filterizer(plusFilter, minusFilter,
                withOutSignFilter);
        Set<String> answers = new HashSet<>();

        String pathOfTheFile = inputs.readInput();
        Map<String, String[]> splitDocumentInfo = invertedIndexMaker.wordSplitter(pathOfTheFile);
        invertedIndexMaker.buildInvertedIndex(splitDocumentInfo);
        answers = filterizer.filter(inputs, answers);
        filterizer.printFilteredAnswers(answers);
    }

}

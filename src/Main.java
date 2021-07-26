import java.util.*;

public class Main {

    public static void main(String[] args) {
        InputReader inputs = new InputReader();
        FileReader fileReader = new FileReader();
        InvertedIndexMaker invertedIndexMaker = new InvertedIndexMaker(fileReader);
        PlusFilter plusFilter = new PlusFilter(invertedIndexMaker);
        WithOutSignFilter withOutSignFilter = new WithOutSignFilter(invertedIndexMaker);
        MinusFilter minesFilter = new MinusFilter(invertedIndexMaker);
        AllFilters allFilters = new AllFilters(plusFilter, minesFilter,
                withOutSignFilter);
        Set<String> answers;

        String pathOfTheFile = inputs.readInput();
        Map<String, String[]> splitDocumentInfo = invertedIndexMaker.wordSpliter(pathOfTheFile);
        invertedIndexMaker.buildInvertedIndex(splitDocumentInfo);
        answers = allFilters.filter(inputs);
        allFilters.printFilteredAnswers(answers);
    }

}

import java.util.*;

public class Main {

    public static void main(String[] args) {
        InputReader inputs = new InputReader();
        FileReader fileReader = new FileReader();
        InvertedIndexMaker invertedIndexMaker = new InvertedIndexMaker(fileReader);
        Filterizer filterizer = new Filterizer(invertedIndexMaker);
        Set<String> answers = new HashSet<>();

        String pathOfTheFile = inputs.readInput();
        Map<String, String[]> splitDocumentInfo = invertedIndexMaker.wordSplitter(pathOfTheFile);
        invertedIndexMaker.buildInvertedIndex(splitDocumentInfo);
        answers = filterizer.filter(inputs, answers);
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

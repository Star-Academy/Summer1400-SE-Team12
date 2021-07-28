package AllTests;

import java.util.HashMap;
import java.util.Map;

import Phase2.FileReader;
import Phase2.InvertedIndexMaker;
import org.junit.Assert;
import org.junit.Test;
import org.mockito.Mock;

import static org.mockito.Mockito.doNothing;
import static org.mockito.Mockito.when;

public class InvertedIndexMakerTest {

    @Mock
    FileReader fileReader;
    InvertedIndexMaker invertedIndexMaker = new InvertedIndexMaker(fileReader);
    final String PATH_OF_FILE = "src\\TesterFile";

    Map<String, String[]> splittedDocumentInfo = new HashMap<>();
    Map<String, String[]> splittedInfo = new HashMap<>();
    Map<String, String> resultOfFileReaderFunc=new HashMap<>();


    @Test
    public void testInvertedIndexMaker() {

        String name1 = "text1";
        String[] words1 = new String[]{"one", "two", "three", "four"};
        splittedDocumentInfo.put(name1, words1);
        String name2 = "text2";
        String[] words2 = new String[]{"five", "six", "seven", "eight", "nine"};
        splittedDocumentInfo.put(name2, words2);
        String name3 = "text3";
        String[] words3 = new String[]{"one", "two", "eleven", "sixty", "seventy", "zero"};
        splittedDocumentInfo.put(name3, words3);

        invertedIndexMaker.buildInvertedIndex(splittedDocumentInfo);

    }



//
//    @Test
//    public void splitDocumentsWordsTest(){
//
//        Map<String, String[]> actualValue=new HashMap<>();
//
//        String fileNameExpected = "text1.txt";
//        String textOfFile = "junit provides a tool for execution of your test cases";
//        resultOfFileReaderFunc.put(fileNameExpected,textOfFile);
//
//        String[] allSplittedWordsInText1 = new String[]{"junit", "provides", "a", "four","tool","for","execution","of","your","test","cases"};
//        splittedInfo.put(fileNameExpected,allSplittedWordsInText1);
//
//        when(fileReader.readDocument(PATH_OF_FILE)).thenReturn(resultOfFileReaderFunc);
//        actualValue= invertedIndexMaker.splitDocumentsWords(PATH_OF_FILE);
//
//        Assert.assertTrue(actualValue.containsKey(fileNameExpected));
//
//    }


}

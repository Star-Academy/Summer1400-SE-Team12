package Tests;

import java.util.HashMap;
import java.util.Map;
//import org.mockito.junit.*;
import Phase02.InvertedIndex;
import org.junit.Assert;
import org.junit.Test;
//import org.mockito.junit.MockitoJUnit;
//import org.mockito.junit.MockitoRule;

import static org.junit.Assert.assertNotNull;
import static org.mockito.Mockito.mock;


public class InvertedIndexMakerTest {

//    public MockitoRule mockitoRule = MockitoJUnit.rule();

    InvertedIndex invertedIndex = new InvertedIndex();
    final String PATH_OF_FILE = "src\\TesterFile";

    Map<String, String> docNameMapToContent = new HashMap<>();

    @Test
    public void testInvertedIndexMaker() {


        String name1 = "text1";
        String sentence1 = "one two";
        docNameMapToContent.put(name1, sentence1);

        String name2 = "text2";
        String sentence2 = "five six seven eight nine";
        docNameMapToContent.put(name2, sentence2);

        String name3 = "text3";
        String sentence3 = "one two";
        docNameMapToContent.put(name3, sentence3);

        invertedIndex.buildInvertedIndex(docNameMapToContent);

        Assert.assertArrayEquals(new String[]{"text3", "text1"},invertedIndex.getInvertedIndexValue("one").toArray());


    }



}

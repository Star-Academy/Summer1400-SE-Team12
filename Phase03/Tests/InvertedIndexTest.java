package Tests;

import java.util.HashMap;
import java.util.Map;

import Phase02.InvertedIndex;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;


public class InvertedIndexTest {

    private InvertedIndex invertedIndex;
    private Map<String, String> docNameMapToContent;

    @Before
    public void setup() {
        invertedIndex = new InvertedIndex();
        docNameMapToContent = new HashMap<>();

        docNameMapToContent.put("text1", "one two");
        docNameMapToContent.put("text2", "five six seven eight nine");
        docNameMapToContent.put("text3", "one two three ");
    }

    @Test
    public void testInvertedIndexWordExistInADoc() {
        invertedIndex.buildInvertedIndex(docNameMapToContent);
        Assert.assertArrayEquals(new String[]{"text2"},
                invertedIndex.getInvertedIndexValue("six").toArray());

    }

    @Test
    public void testInvertedIndexWordExistInTwoDoc() {
        invertedIndex.buildInvertedIndex(docNameMapToContent);
        Assert.assertArrayEquals(new String[]{"text3", "text1"},
                invertedIndex.getInvertedIndexValue("one").toArray());

    }

    @Test
    public void testInvertedIndexWordNotExistInDoc() {
        invertedIndex.buildInvertedIndex(docNameMapToContent);
        Assert.assertArrayEquals(new String[]{},
                invertedIndex.getInvertedIndexValue("ten").toArray());

    }

}

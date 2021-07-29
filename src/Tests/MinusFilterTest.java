package Tests;

import Phase2.InvertedIndexMaker;
import Phase2.MinusFilter;

import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.*;

import static org.mockito.Matchers.any;


@RunWith(MockitoJUnitRunner.class)
public class MinusFilterTest {

    private MinusFilter minusFilter;

    @Mock
    InvertedIndexMaker MockInvertedIndexMaker;

    @Before
    public void setup(){
        this.minusFilter = new MinusFilter(MockInvertedIndexMaker);
    }

    @Test
    public void testMinusFilter(){
        Mockito.doAnswer(invocation -> {
            Map<String, Set<String>> invertedIndex = returnSampleInvertedIndexForTest();
            return null;
        }).when(MockInvertedIndexMaker).buildInvertedIndex( any(Map.class) );
        
    }

    public Map<String, Set<String>> returnSampleInvertedIndexForTest(){
        Map<String, Set<String>> sampleInvertedIndex = new HashMap<>();

        Set<String> documentsHelloContain = new HashSet<>(Arrays.asList("1","2","3"));
        sampleInvertedIndex.put("hello",new HashSet<>(documentsHelloContain));

        Set<String> documentsWorldContain = new HashSet<>(Arrays.asList("2","3"));
        sampleInvertedIndex.put("world", documentsWorldContain);

        Set<String> documentsMockContain = new HashSet<>(Arrays.asList("1","5","2"));
        sampleInvertedIndex.put("mock", documentsMockContain);
        return sampleInvertedIndex;
    }
}

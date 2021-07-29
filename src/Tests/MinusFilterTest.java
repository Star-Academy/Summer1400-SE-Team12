package Tests;

import Phase2.InvertedIndexMaker;
import Phase2.MinusFilter;

import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;

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
            invocation.getArguments()[0] = returnSampleInvertedIndexForTest();
//            Map<String, Set<String>> invertedIndex = (Map<String, Set<String>>) invocation.getArguments()[0];
//            Assert.assertTrue(invertedIndex.containsKey("hello"));
            return null;
        }).when(MockInvertedIndexMaker).buildInvertedIndex( any(Map.class) );
        MockInvertedIndexMaker.buildInvertedIndex(new HashMap<>());
//        verify(MockInvertedIndexMaker,times(1)).buildInvertedIndex()
//        Assert.assertEquals(3,MockInvertedIndexMaker.invertedIndex.size());
//        Set<String> minusFilteredActual = minusFilter.filter(new HashSet<>(Arrays.asList("hello","world")),
//                new HashSet<>(Arrays.asList("1","2","3","4","5","6")));
//        String[] expected = {"4","5","6"};
//        Assert.assertArrayEquals(expected, minusFilteredActual.toArray());
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

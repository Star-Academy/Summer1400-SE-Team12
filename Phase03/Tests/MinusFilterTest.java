package Tests;

import Phase02.MinusFilter;
import org.junit.*;
import java.util.*;

public class MinusFilterTest {

    private MinusFilter minusFilter;

    @Before
    public void setup(){
        minusFilter = new MinusFilter();
    }

    @Test
    public void testMinusFilterPreFilteredContainDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4","doc9"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc4","doc7","doc10","doc9"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5"));
        minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testMinusFilterPreFilteredNotContainDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc6"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4"));
        minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testMinusFilterEmptyPreFiltered(){
        Set<String> preFiltered = new HashSet<>();
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc8"));

        final Set<String> expectedFiltered = new HashSet<>();
        minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testMinusFilteredEmptyDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc5","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>();

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc5","doc4"));
        minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }
}

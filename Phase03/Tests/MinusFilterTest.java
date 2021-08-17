package Tests;

import Phase02.MinusFilter;
import org.junit.*;
import java.util.*;

public class MinusFilterTest {

    private MinusFilter minusFilter;

    @Before
    public void setup(){
        this.minusFilter = new MinusFilter();
    }

    @Test
    public void testMinusFilterPreFilteredContainDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4","doc9"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc4","doc7","doc10","doc9"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5"));
        this.minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testMinusFilterPreFilteredNotContainDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc6"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc5","doc7","doc4"));
        this.minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testMinusFilterEmptyPreFiltered(){
        Set<String> preFiltered = new HashSet<>();
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc8"));

        Set<String> expectedFiltered = new HashSet<>();
        this.minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testMinusFilteredEmptyDocumentsWithMinusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc5","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>();

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc5","doc4"));
        this.minusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }
}

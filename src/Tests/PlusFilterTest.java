package Tests;

import Phase02.PlusFilter;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class PlusFilterTest {
    private PlusFilter plusFilter;

    @Before
    public void setup(){
        this.plusFilter = new PlusFilter();
    }

    @Test
    public void testPlusFilterPreFilteredContainHalfOfDocumentsWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc4","doc5"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4","doc5","doc6"));
        this.plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testPlusFilteredDocumentsWithPLusQueryISSubSetOfPreFiltered(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc6"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        this.plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testPPlusFilterPreFilteredNotContainDocumentsWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc6","doc7","doc8"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4", "doc6","doc7","doc8"));
        this.plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testPLusFilterEmptyPreFiltered(){
        Set<String> preFiltered = new HashSet<>();
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc4","doc5","doc6"));

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc3","doc4","doc5","doc6"));
        this.plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testPlusFilterEmptyDocumentWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc3","doc5","doc4","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>();

        Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc3","doc4","doc6","doc5"));
        this.plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }
}

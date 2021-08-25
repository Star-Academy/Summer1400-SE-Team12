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
        plusFilter = new PlusFilter();
    }

    @Test
    public void testPlusFilterPreFilteredContainHalfOfDocumentsWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc4","doc5"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4","doc5","doc6"));
        plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testPlusFilteredDocumentsWithPLusQueryISSubSetOfPreFiltered(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc6"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc6"));
        plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testPPlusFilterPreFilteredNotContainDocumentsWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4"));
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc6","doc7","doc8"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4", "doc6","doc7","doc8"));
        plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testPLusFilterEmptyPreFiltered(){
        Set<String> preFiltered = new HashSet<>();
        Set<String> documentsContainMinusQuery = new HashSet<>(Arrays.asList("doc3","doc4","doc5","doc6"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc3","doc4","doc5","doc6"));
        plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testPlusFilterEmptyDocumentWithPlusQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc3","doc5","doc4","doc6"));
        Set<String> documentsContainMinusQuery = new HashSet<>();

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc3","doc4","doc6","doc5"));
        plusFilter.filter(documentsContainMinusQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }
}

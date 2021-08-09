package Tests;

import Phase02.WithoutSignFilter;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class WithoutSignFilterTest {
    private WithoutSignFilter withoutSignFilter;

    @Before
    public void setup(){
        withoutSignFilter = new WithoutSignFilter();
    }

    @Test
    public void testWithoutSignFilterDocumentsISSubSetOfPreFiltered() {
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4","doc5","doc6"));
        Set<String> documentsContainWithoutSignQuery = new HashSet<>(Arrays.asList("doc2","doc4","doc6"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc2","doc4","doc6"));
        withoutSignFilter.filter(documentsContainWithoutSignQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertArrayEquals(expectedFiltered.toArray(), actualFiltered.toArray());
    }

    @Test
    public void testWithoutSignFilterPreFilteredContainHalfOfDocumentsWithNoSignQuery(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4","doc5","doc6"));
        Set<String> documentsContainWithoutSignQuery = new HashSet<>(Arrays.asList("doc2","doc4","doc7","doc8"));

        final Set<String> expectedFiltered = new HashSet<>(Arrays.asList("doc2","doc4"));
        withoutSignFilter.filter(documentsContainWithoutSignQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testWithoutSignFilterPreFilterNotContainDocs(){
        Set<String> preFiltered = new HashSet<>(Arrays.asList("doc1","doc2","doc3","doc4"));
        Set<String> documentsContainWithoutSignQuery = new HashSet<>(Arrays.asList("doc7","doc8","doc9"));

        final Set<String> expectedFiltered = new HashSet<>();
        withoutSignFilter.filter(documentsContainWithoutSignQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }

    @Test
    public void testWithoutSignFilterEmptyPreFiltered(){
        Set<String> preFiltered = new HashSet<>();
        Set<String> documentsContainWithoutSignQuery = new HashSet<>(Arrays.asList("doc2","doc4"));

        final Set<String> expectedFiltered = new HashSet<>();
        withoutSignFilter.filter(documentsContainWithoutSignQuery,preFiltered);
        Set<String> actualFiltered = preFiltered;

        Assert.assertEquals(expectedFiltered, actualFiltered);
    }
}

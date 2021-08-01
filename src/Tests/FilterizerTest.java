package Tests;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import Phase02.*;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;


@RunWith(MockitoJUnitRunner.class)
public class FilterizerTest {

    @Mock
    PlusFilter mockedPlusFilter;
    @Mock
    MinusFilter mockedMinusFilter;
    @Mock
    WithoutSignFilter mockedWithOutSignFilter;
    @Mock
    InvertedIndex mockedInvertedIndex;
    @Mock
    QueryKeeper mockedQueryKeeper;

    private Set<String> documentsName;
    private Filterizer filterizer;
    private Set<String> plusContain;
    private Set<String> withoutSignContain;
    private Set<String> minusContain;

    @Before
    public void setup() {
        this.documentsName = new HashSet<>(Arrays.asList("t1", "t2", "t3", "t4", "t5", "t6",
                "t7", "t8", "t9", "t10", "t11", "t12"));
        this.filterizer = new Filterizer(mockedPlusFilter, mockedMinusFilter,
                mockedWithOutSignFilter, mockedInvertedIndex);

        plusContain = new HashSet<>(Arrays.asList("1"));
        withoutSignContain = new HashSet<>(Arrays.asList("1"));
        minusContain = new HashSet<>(Arrays.asList("1"));

        Mockito.when(mockedQueryKeeper.getMinusContain()).thenReturn(minusContain);
        Mockito.when(mockedQueryKeeper.getPlusContain()).thenReturn(plusContain);
        Mockito.when(mockedQueryKeeper.getWithOutSign()).thenReturn(withoutSignContain);
        Mockito.when(mockedInvertedIndex.getInvertedIndexValue(Mockito.anyString())).thenReturn(new HashSet<>());
    }


    @Test
    public void testFilterizerWithAllTypesOfFilter() {
        stubbleMockedObjectsMethod();

        Set<String> filtered = filterizer.filterDocuments(mockedQueryKeeper,documentsName);
        Assert.assertArrayEquals(new String[]{"t4","t3"},filtered.toArray());
    }

    @Test
    public void testFilterizerWithoutPlusQuery(){
        plusContain.clear();
        stubbleMockedObjectsMethod();

        Set<String> filtered = filterizer.filterDocuments(mockedQueryKeeper,documentsName);
        Assert.assertArrayEquals(new String[]{"t4","t3"},filtered.toArray());
    }

    @Test
    public void testFilterizerWithoutNoSignQuery(){
        withoutSignContain.clear();
        stubbleMockedObjectsMethod();

        Set<String> filtered = filterizer.filterDocuments(mockedQueryKeeper,documentsName);
        Assert.assertArrayEquals(new String[]{"t4","t5","t1","t3"},filtered.toArray());
    }

    @Test
    public void testFilterizerWithoutMinusQuery(){
        minusContain.clear();
        stubbleMockedObjectsMethod();

        Set<String> filtered = filterizer.filterDocuments(mockedQueryKeeper,documentsName);
        Assert.assertArrayEquals(new String[]{"t4","t2","t3"},filtered.toArray());
    }

    private void stubbleMockedObjectsMethod(){
        Mockito.doAnswer(invocation -> {
            Set<String> arg1 = (HashSet) invocation.getArguments()[1];
            arg1.addAll(Arrays.asList("t1", "t2", "t3","t4","t5"));
            return null;
        }).when(mockedPlusFilter).filter(Mockito.anySet(), Mockito.anySet());
        Mockito.doAnswer(invocation -> {
            Set<String> arg1 = (HashSet) invocation.getArguments()[1];
            arg1.retainAll(Arrays.asList("t4","t2","t3"));
            return null;
        }).when(mockedWithOutSignFilter).filter(Mockito.anySet(),Mockito.anySet());
        Mockito.doAnswer(invocation -> {
            Set<String> arg1 = (HashSet) invocation.getArguments()[1];
            arg1.remove("t2");
            return null;
        }).when(mockedMinusFilter).filter(Mockito.anySet(),Mockito.anySet());
    }

}

package Tests;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import Phase02.*;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
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

    @Before
    public void setup() {
        this.documentsName = new HashSet<>(Arrays.asList("t1","t2","t3","t4","t5", "t6",
                "t7", "t8","t9","t10","t11","t12"));
        Filterizer filterizer = new Filterizer(mockedPlusFilter, mockedMinusFilter, mockedWithOutSignFilter,
                mockedInvertedIndex, documentsName);
    }


    @Test
    public void testFilterizerWithAllTypesOfFilter() {
        Set<String> plusDocsName = new HashSet<>(Arrays.asList("t1","t2","t3"));
        Set<String> minusDocsName = new HashSet<>(Arrays.asList("t4","t5","t6"));
        Set<String> noneDocsName = new HashSet<>(Arrays.asList("t1","t7","t8"));

        Mockito.when(mockedQueryKeeper.getPlusContain()).thenReturn(plusDocsName);
        Mockito.when(mockedQueryKeeper.getMinusContain()).thenReturn(minusDocsName);
        Mockito.when(mockedQueryKeeper.getWithOutSign()).thenReturn(noneDocsName);

        Mockito.doAnswer(invocation -> {
            
        }).when(mockedPlusFilter).filter(Mockito.anySet(),Mockito.anySet());

//        Set<String> nullSet = new HashSet<>();
//
//        Set<String> plusFiltered = new HashSet<>();
//        plusFiltered.add("plus1");
//        plusFiltered.add("plus2");
//        plusFiltered.add("plus3");
//
//        Set<String> withoutSignFiltered = new HashSet<>();
//        withoutSignFiltered.add("none1");
//        withoutSignFiltered.add("none2");
//        withoutSignFiltered.add("none3");
//
//        Set<String> minusFiltered = new HashSet<>();
//        minusFiltered.add("plus1");
//        minusFiltered.add("minus2");
//        minusFiltered.add("minus3");
//

//

//
//        Mockito.when(plusFilter.filter(plusFiltered, nullSet)).thenReturn(plusDocsName);
//        Mockito.when(minusFilter.filter(minusFiltered, nullSet)).thenReturn(minusDocsName);
//        Mockito.when(withOutSignFilter.filter(withoutSignFiltered, nullSet)).thenReturn(noneDocsName);
//
//        String testedFiltered = "t1";
//        //کلمه مشترک بین شان Todo
//
//        Set<String> resultFiltered;
//        resultFiltered = filterizer.filter(queryKeeper);
//
//        Assert.assertTrue(resultFiltered.contains(testedFiltered));

    }


}

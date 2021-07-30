package Tests;
import java.util.HashSet;
import java.util.Set;

import Phase2.*;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;

import static org.mockito.Mockito.when;

@RunWith(MockitoJUnitRunner.class)
public class FilterizerTest {

    @Mock
    PlusFilter plusFilter;

    @Mock
    MinusFilter minusFilter;

    @Mock
    WithoutSignFilter withOutSignFilter;

    Set<String> documentsName=new HashSet<>();

    Filterizer filterizer=new Filterizer(plusFilter,minusFilter,withOutSignFilter,documentsName);

    @Mock
    QueryKeeper queryKeeper;


    @Test
    public void testFilter() {

        Set<String> nullSet = new HashSet<>();

        Set<String> plusFiltered = new HashSet<>();
        plusFiltered.add("plus1");
        plusFiltered.add("plus2");
        plusFiltered.add("plus3");

        Set<String> withoutSignFiltered = new HashSet<>();
        withoutSignFiltered.add("none1");
        withoutSignFiltered.add("none2");
        withoutSignFiltered.add("none3");

        Set<String> minusFiltered = new HashSet<>();
        minusFiltered.add("plus1");
        minusFiltered.add("minus2");
        minusFiltered.add("minus3");

        Set<String> plusDocsName = new HashSet<>();
        plusDocsName.add("t1");
        plusDocsName.add("t2");
        plusDocsName.add("t3");

        Set<String> minusDocsName = new HashSet<>();
        plusDocsName.add("t4");
        plusDocsName.add("t5");
        plusDocsName.add("t6");

        Set<String> noneDocsName = new HashSet<>();
        plusDocsName.add("t1");
        plusDocsName.add("t7");
        plusDocsName.add("t8");

        Mockito.when(queryKeeper.getMinusContain()).thenReturn(minusFiltered);
        Mockito.when(queryKeeper.getPlusContain()).thenReturn(plusFiltered);
        Mockito.when(queryKeeper.getWithOutSign()).thenReturn(withoutSignFiltered);

        Mockito.when(plusFilter.filter(plusFiltered,nullSet)).thenReturn(plusDocsName);
        Mockito.when(minusFilter.filter(minusFiltered,nullSet)).thenReturn(minusDocsName);
        Mockito.when(withOutSignFilter.filter(withoutSignFiltered,nullSet)).thenReturn(noneDocsName);

        String testedFiltered = "t1";
        //کلمه مشترک بین شان Todo

        Set<String> resultFiltered;
        resultFiltered=filterizer.filter(queryKeeper);

        Assert.assertTrue(resultFiltered.contains(testedFiltered));

    }





}

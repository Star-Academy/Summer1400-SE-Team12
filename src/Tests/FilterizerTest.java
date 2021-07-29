package Tests;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import Phase2.*;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;


@RunWith(MockitoJUnitRunner.class)
public class FilterizerTest {

    @Mock
    PlusFilter plusFilter;

    @Mock
    MinusFilter minusFilter;

    @Mock
    WithoutSignFilter withOutSignFilter;

    @Mock
    QueryKeeper queryKeeper;

    Filterizer filterizer;
    @Before
    public void setup(){
        Set<String> documentsName = new HashSet<>();
        this.filterizer = new Filterizer(plusFilter,minusFilter,withOutSignFilter,documentsName);
    }
    @Test
    public void testFilter() {

        Set<String> plusQueryCategory = new HashSet<>();
        plusQueryCategory.add("plus1");
        plusQueryCategory.add("plus2");
        plusQueryCategory.add("plus3");

        Set<String> withoutSignQueryCategory = new HashSet<>();
        withoutSignQueryCategory.add("none1");
        withoutSignQueryCategory.add("none2");
        withoutSignQueryCategory.add("none3");

        Set<String> minusQueryCategory = new HashSet<>();
        minusQueryCategory.add("plus1");
        minusQueryCategory.add("minus2");
        minusQueryCategory.add("minus3");

        Mockito.when(queryKeeper.getMinusContain()).thenReturn(minusQueryCategory);
        Mockito.when(queryKeeper.getPlusContain()).thenReturn(plusQueryCategory);
        Mockito.when(queryKeeper.getWithOutSign()).thenReturn(withoutSignQueryCategory);

        String testedFiltered = "plus1";

        Set<String> resultFiltered = filterizer.filter(queryKeeper);

        Assert.assertTrue(resultFiltered.contains(testedFiltered));

    }





}

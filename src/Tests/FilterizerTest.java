package AllTests;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import Phase2.*;
import org.junit.Assert;
import org.junit.Test;
import org.mockito.Mock;

import static org.mockito.Mockito.when;


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
        Set<String> plusFiltered = new HashSet<>();
        plusFiltered.add("plus1");
        plusFiltered.add("plus2");
        plusFiltered.add("plus3");

        Set<String> withoutSignFiltered = new HashSet<>();
        withoutSignFiltered.add("none1");
        withoutSignFiltered.add("none2");
        withoutSignFiltered.add("none3");

        Set<String> minusFiltered = new HashSet<>();
        minusFiltered.add("minus1");
        minusFiltered.add("minus2");
        minusFiltered.add("minus3");

        when(queryKeeper.getMinusContain()).thenReturn(minusFiltered);
        when(queryKeeper.getPlusContain()).thenReturn(plusFiltered);
        when(queryKeeper.getWithOutSign()).thenReturn(withoutSignFiltered);

        filterizer.filter(queryKeeper);

//        Assert.assertNotNull();

    }


    @Test
    public void testSubscribeFiltered() {


    }


}

package Tests;

import Phase2.InvertedIndexMaker;
import Phase2.MinusFilter;

import org.junit.*;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;


public class MinusFilterTest {

    private MinusFilter minusFilter;

    @Mock
    InvertedIndexMaker invertedIndexMaker;

    @Before
    public void setup(){
        this.minusFilter = new MinusFilter(invertedIndexMaker);
    }

    @Test
    public void testMinusFilter(){
        Assert.assertNotNull(invertedIndexMaker);
    }

}

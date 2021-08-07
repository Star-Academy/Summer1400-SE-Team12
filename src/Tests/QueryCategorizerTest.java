package Tests;

import Phase02.QueryCategorizer;

import Phase02.QueryKeeper;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.ByteArrayInputStream;
import java.util.HashSet;
import java.util.Scanner;

@RunWith(MockitoJUnitRunner.class)
public class QueryCategorizerTest {

    @Mock
    private Scanner mockedScanner;

    private QueryCategorizer queryCategorizer;

    @Before
    public void setup(){
        queryCategorizer = new QueryCategorizer();
        String query = "mom dad +sister +sisi -brother -bro";
        System.setIn(new ByteArrayInputStream(query.getBytes()));
    }

    @Test
    public void testCategorizeForNoSignQueries() {
        QueryKeeper queryKeeper = queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"dad","mom"},
                queryKeeper.getWithOutSign().toArray());

    }

    @Test
    public void testCategorizeForPlusQueries() {
        QueryKeeper queryKeeper = queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"sisi","sister"},
                queryKeeper.getPlusContain().toArray());

    }

    @Test
    public void testCategorizeForMinusQueries() {
        QueryKeeper queryKeeper = queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"brother","bro"},
                queryKeeper.getMinusContain().toArray());

    }


}
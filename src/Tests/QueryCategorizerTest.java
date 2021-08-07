package Tests;

import Phase02.QueryCategorizer;

import Phase02.QueryKeeper;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.runners.MockitoJUnitRunner;

import java.io.ByteArrayInputStream;

@RunWith(MockitoJUnitRunner.class)
public class QueryCategorizerTest {


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
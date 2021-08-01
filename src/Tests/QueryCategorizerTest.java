package Tests;

import Phase02.QueryCategorizer;

import org.junit.*;
import java.io.ByteArrayInputStream;

public class QueryCategorizerTest {

    private QueryCategorizer queryCategorizer;

    @Before
    public void setup(){
        this.queryCategorizer = new QueryCategorizer();
        String query = "mom dad +sister +sisi -brother -bro";
        System.setIn(new ByteArrayInputStream(query.getBytes()));
    }

    @Test
    public void testCategorizeForNoSignQueries() {
        queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"dad","mom"},
                queryCategorizer.getQueryKeeper().getWithOutSign().toArray());

    }

    @Test
    public void testCategorizeForPlusQueries() {
        queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"sisi","sister"},
                queryCategorizer.getQueryKeeper().getPlusContain().toArray());

    }

    @Test
    public void testCategorizeForMinusQueries() {
        queryCategorizer.categorizeQuery();
        Assert.assertArrayEquals(new String[]{"brother","bro"},
                queryCategorizer.getQueryKeeper().getMinusContain().toArray());

    }


}
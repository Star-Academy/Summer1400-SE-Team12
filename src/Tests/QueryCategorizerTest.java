package Tests;

import Phase2.QueryCategorizer;
import org.junit.Assert;
import org.junit.Test;
import org.mockito.Mock;

import java.io.ByteArrayInputStream;

public class QueryCategorizerTest {
    @Mock
    QueryCategorizer queryCategorizer;

    @Test
    public void testCategorizeQuery() {

        String query = "mom dad +sister +sisi -brother -bro";
        System.setIn(new ByteArrayInputStream(query.getBytes()));

        Assert.assertTrue(String.valueOf(queryCategorizer.getQuery().isEmpty()),false);
        // bayad toye  (queryCategorizer.getQuery().isEmpty())  poor bashe va false bede



    }


}
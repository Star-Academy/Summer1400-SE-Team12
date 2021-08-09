package Tests;

import java.util.Map;

import Phase02.FileReader;
import org.junit.Assert;
import org.junit.Test;

public class FileReaderTest {

    @Test
    public void testFileReader() {

        FileReader fileReader = new FileReader();

        final String textFileExpected = "JUnit provides a tool for execution of your test cases";
        final String fileNameExpected = "text1.txt";
        final String pathOfFile = "src\\TesterFile";
        Map<String, String> actualValue = fileReader.readDocuments(pathOfFile);

        Assert.assertTrue(actualValue.containsKey(fileNameExpected));
        Assert.assertEquals(textFileExpected.toLowerCase(),actualValue.get(fileNameExpected));

    }
}



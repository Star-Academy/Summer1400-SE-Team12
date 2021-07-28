package Tests;
import Phase2.FileReader;

import java.util.Map;
import org.junit.Assert;
import org.junit.Test;

public class FileReaderTest {

    @Test
    public void testFileReader() {
        FileReader fileReader = new FileReader();
        String textFileExpected = "JUnit provides a tool for execution of your test cases.";
        String fileNameExpected = "text1.txt";

        final String  PATH_OF_FILE = "src\\TesterFile";
        Map<String, String> actualValue = fileReader.readDocuments(PATH_OF_FILE);

        Assert.assertTrue(actualValue.containsKey(fileNameExpected));
        Assert.assertTrue(actualValue.containsValue(textFileExpected.toLowerCase()));
    }
}



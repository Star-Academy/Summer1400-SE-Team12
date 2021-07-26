import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

public class FileReader {
    public Map<String, String> readDocument(String path) {
        Map<String, String> document = new HashMap<>();
        try {
            File sourceFolder = new File(path);
            for (File sourceFile : sourceFolder.listFiles()) {
                String fileName = sourceFile.getName();
                document.put(fileName, Files.readString(Path.of(path + "\\" + fileName)).
                        toLowerCase());//open file
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return document;
    }
}
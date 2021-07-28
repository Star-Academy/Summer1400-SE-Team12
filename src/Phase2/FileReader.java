package Phase2;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

public class FileReader {
    public Map<String, String> readDocument(String path) {
        final String Back_SLASH = "\\";
        final String documentsAddress = path + Back_SLASH;
        Map<String, String> documents = new HashMap<>();
        try {
            File sourceFolder = new File(path);
            for (File sourceFile : sourceFolder.listFiles()) {
                String fileName = sourceFile.getName();
                documents.put(fileName, Files.readString(Path.of(documentsAddress, fileName)).
                        toLowerCase());//open file
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return documents;
    }
}
package Phase02;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.HashMap;
import java.util.Map;

public class FileReader {
    public Map<String, String> readDocuments(String path) {
        Map<String, String> documents = new HashMap<>();
        try {
            File sourceFolder = new File(path);
            for (File sourceFile : sourceFolder.listFiles()) {
                String fileName = sourceFile.getName();
                documents.put(fileName, Files.readString(Path.of(path, fileName)).
                        toLowerCase());//open file
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return documents;
    }
}
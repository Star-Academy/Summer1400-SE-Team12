import java.util.*;

public class Phase01 {


    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String path = sc.next();
        Researcher.buildInvertedIndex(path);
        System.out.println("please enter a query");

        Set<String> plusContain = new HashSet<>();
        Set<String> minusContain = new HashSet<>();
        Set<String> none = new HashSet<>();

        sc.nextLine();
        splitInput(sc.nextLine().split(" "), plusContain,
                minusContain,none);


        Set<String> answers = new HashSet<>();

        for (String plus : plusContain) {
            String pureWord = plus.substring(1);
            if (Researcher.invertedIndex.containsKey(pureWord))
                answers.addAll(Researcher.invertedIndex.get(pureWord));
        }


        for (String n : none) {
            if (Researcher.invertedIndex.containsKey(n)) {
                if (answers.size() == 0)
                    answers.addAll(Researcher.invertedIndex.get(n));
                else{
                    answers.retainAll(Researcher.invertedIndex.get(n)); // question
                }
            }else
            {
                answers.clear();
                break;
            }
        }

        for (String minus : minusContain) {
            String pureWord = minus.substring(1);
            if (Researcher.invertedIndex.containsKey(pureWord))
                answers.removeAll(Researcher.invertedIndex.get(pureWord));
        }


        System.out.println(answers.toString());

    }


    public static void splitInput(String[] query, Set<String> plusContain,
                                  Set <String> minusContain, Set<String> none){
        for (String q : query) {
            if (q.contains("+")) {
                plusContain.add(q);
            } else if (q.contains("-")) {
                minusContain.add(q);
            } else {
                none.add(q);
            }

        }
    }

}

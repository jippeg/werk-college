namespace project;
class Program {
    static void Main(string[] args) {
        var ls = new Lambdas();
        //oefeningen
        ls += () => {
            int x = ask_int("x? ");
            if (x >= 0) print("positief");
            else print("negatief");
            int temp = ask_int("temp? ");
            if (temp <= 10) {
                print("koud");
            } else if (temp >= 10 && temp <= 20) {
                print("goed");
            } else {
                print("warm");
            }
            x = ask_int("x? ");
            bool real = x >= 0;
            bool even = x % 2 == 0;
            if (real && even) {
                print("positief en even");
            } else if (real && !even) {
                print("positief en oneven");
            } else if (!real && even) {
                print("negatief en even");
            } else{
                print("negatief en oneven");
            }
            return "Geneste selecties";
        };
        ls += () => {
            int aantal = ask_int("aantal? ");
            print(aantal == 1 ? "student" : "studenten");
            return "Conditionele operator";
        };
        ls += () => {
            //vraag a
            int i = ask_int("waarde? ");
            int k;
            switch(i) {
                case 1:
                    k = 3;
                    break;
                case 2:
                    k = 6;
                    break;
                case 3:
                case 4:
                    k = 10;
                    break;
                default:
                    k = 20;
                    break;
            }
            print($"k = {k}");
            //vraag b
            int x = ask_int("x?");
            int y = 0;
            switch(x) {
                case 100:
                case 150:
                case 170:
                case 199:
                    ++y;
                    break;
            }
            return "Switch-case";
        };
        ls += () => {
            int i = 1, j = 2, k = 3, m = 2;
            print(i == 1);
            print(j == 3);
            print(i >= 1 && j < 4);
            print(m <= 99 & k < m);
            print(m >= i || k == m);
            print(k + m < j | 3 - j >= k);
            print(!(k > m));
            return "Logische operatoren";
        };
        ls += () => {
            const int size = 3;
            int[] arr = new int[size];
            arr[0] = ask_int("geef eerste getal in: ");
            arr[1] = ask_int("geef tweede getal in: ");
            arr[2] = ask_int("geef derde getal in: ");
            print($"van de ingevoerde getallen {arr[0]}, {arr[1]} en {arr[2]}");
            int sum = arr.Sum();
            print($"is de som {sum}");
            print($"het gemiddelde {sum / size}");
            print($"de rest {sum % size}");
            int biggest = int.MinValue;
            foreach(int i in arr) if (biggest < i) biggest = i;
            print($"en het grootste getal {biggest}");
            return "Som, gemiddelde, rest en het grootste getal";
        };
        ls += () => {

            var postcodes = new Dictionary<int, string>{
                {9300, "Aalst"}, {2000, "Antwerpen"},
                {1000, "Brussel"}, {9200, "Dendermonde"},
                {9000, "Gent"}, {8500, "Kortrijk"},
                {9700, "Oudenaarde"}, {2300, "Turnhout"}
            };
            int pc = ask_int("Geef een postcode (4 cijfers): ", (int n) => {return postcodes.ContainsKey(n);});
            print($"Postnummer {pc} komt overeen met de stad {postcodes[pc]}");
            return "Postcode";
        };
        //printen van oefeningen
        const string oefening_param = "--oefening";
        if (args.Contains(oefening_param)) {
            int idx = Array.IndexOf(args, oefening_param);
            int oef_idx;
            if (int.TryParse(args[idx + 1], out oef_idx)) {
                --oef_idx;
                print_oef(ref ls, oef_idx);
            }
        } else {
            int count = ls.data.Count();
            for (int i = 0; i < count; ++i) {
                print_oef(ref ls, i);
            }
        }
    }
    static void print_oef(ref readonly Lambdas ls, int idx) {
        int n = idx + 1;
        Console.WriteLine($"[begin] oefening {n}:");
        Console.WriteLine($"[einde] {ls.data[idx]()} (oefening {n})" );
    }
    static int ask_int(string? question = null, Func<int, bool>? predicate = null, string? failmsg = null) {
        Console.Write(question ?? "int? ");
        int input;
        _ = int.TryParse(Console.ReadLine(), out input);
        if (predicate == null) return input;
        while (!predicate(input)) {
            Console.Write(failmsg != null ? failmsg : "invalid. probeer opnieuw: ");
            _ = int.TryParse(Console.ReadLine(), out input);
        }
        return input;
    }
    static void print<T>(T arg) {
        Console.WriteLine(arg?.ToString() ?? "#");
    }
}
struct Lambdas {
    public Lambdas() {data = new List<Func<string>>{};}
    public List<Func<string>> data;
    public static Lambdas operator +(Lambdas self, Func<string> lambda) {
        self.data.Add(lambda);
        return self;
    }
}

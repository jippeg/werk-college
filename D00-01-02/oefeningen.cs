namespace project;
class Ex1: Exercise {
    public Ex1(): base(1, "Rekenkundige bewerkingen") {}
    public override void start() {
        result( 2f + 3 * 4 );
        result( (2f + 3) * 4 );
        result( 6f * 3 / 2 * 4 );
        result( 6f * 3 / (2 * 4) );
        result( 6f * (8 % (2 * 3)) );
        result( 17f / 8 + 9 % 5 - 3 * 2 );
        result( 17f / (8 + 9) % (5 - 3) * 2 );
        result( 12f / (2 * 8 % 4) );
        result( 20f * 17 / 8 % 4 );
    }
    static uint curr_ = 0;
    static void result<T>(T result) {
        format_print($"{curr_++}) resultaat is {result}\n");
    }
}
class Ex2: Exercise {
    public Ex2(): base(2, "Calculator") {}
    public override void start() {
        var nums = new List<int>();
        for (int i = 1; i <= 3; ++i) {
            format_print($"Geef getal {i}: ");
            int input;
            int.TryParse(Console.ReadLine(), out input);
            while (input == 0) {
                format_print("Probeer opnieuw: ");
                int.TryParse(Console.ReadLine(), out input);
            }
            nums.Add(input);
        }
        int result = 1;
        foreach (int val in nums) result *= val;
        format_print($"Het resultaat is {result}");
    }
}
class Ex3: Exercise {
    public Ex3(): base(3, "Maandsalaris") {}
    public override void start() {
        format_print("Geef maandsalaris in euro:");
        decimal salaris;
        decimal.TryParse(Console.ReadLine(), out salaris);
        decimal jaarsalaris = salaris * 12;
        format_print($"jaarsalaris = {jaarsalaris}\n");
        format_print($"vakantiegeld = {jaarsalaris * .08m}\n");
    }
}
class Ex4: Exercise {
    public Ex4(): base(4, "Rechthoek: omtrek en oppervlakte") {}
    public override void start() {
        int w, h;
        format_print("lengte?: ");
        int.TryParse(Console.ReadLine(), out w);
        format_print("breedte?: ");
        int.TryParse(Console.ReadLine(), out h);
        format_print($"omtrek: {w * 2 + h * 2}\n");
        format_print($"oppervlakte: {w * h}\n");
    }
}
class Ex5: Exercise {
    public Ex5(): base(5, "Getallen opsplitsen") {}
    public override void start() {
        string[] notations = {
            "eenheden",
            "tientallen",
            "honderdtallen",
            "duizendtallen",
        };
        const int min = 0;
        int max = notations.Count();
        double max_val = to_base10(max) - 1;
        format_print($"geef een getal [{to_base10(min)}, {max_val}]: ");
        string? input = null;
        bool is_first_iteration = true;
        while (input == null) {
            if (is_first_iteration) is_first_iteration = false;
            else format_print("illegaal getal, probeer opnieuw: ");
            input = Console.ReadLine();
            if (input == null) continue;
            double val = double.Parse(input);
            if (val >= max_val) {
                input = null;
                continue;
            }
        }
        int count = input.Count();
        for (int i = 0; i < count; ++i) {
            int i_lerp = count - 1 - i;
            format_print($"{input[i_lerp]} {notations[i]}\n");
        }
    }
    double to_base10(double exponent) {
        return Math.Pow(10, exponent);
    }
}
class Ex6: Exercise {
    public Ex6(): base(6, "Tabel") {}
    public override void start() {
        format_print("Geef een positief getal: ");
        string? input = Console.ReadLine();
        if (input == null) return;
        int n = int.Parse(input);
        if (n < 0) return;
        write_em(1);
        write_em(n);
    }
    void write_em(int coeff) {
        for (int i = 0; i < 5; ++i) {
            Console.Write($"\t{coeff *= 10}");
        }
        Console.Write('\n');
    }
}

class Ex7: Exercise {
    public Ex7(): base(7, "Som, gemiddelde en restwaarde") {
    }
    public override void start() {
        const int N = 3;
        int[] arr = {0, 0, 0};
        for (int i = 0; i < N; ++i) {
            string postfix = i == 0 ? "ste" : "de";
            format_print($"geef {i + 1}{postfix} getal in: ");
            string? input = Console.ReadLine();
            if (input == null) return;
            arr[i] = int.Parse(input);
        }
        format_print($"van de ingevoerde getallen {arr[0]}, {arr[1]} en {arr[2]}\n");
        int sum = arr.Sum();
        format_print($"is de som {sum}\n");
        format_print($"het gemiddelde {sum / N}\n");
        format_print($"de rest {sum % N}\n");
    }
}

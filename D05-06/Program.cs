int section_counter = 1;
int question_counter = 0;
section("De output van een applicatie met een lus");
question();
int y, x = 1, total = 0;
while (x <= 10) {
    y = x * x;
    Console.WriteLine(y.ToString());
    total += y;
    ++x;
}
Console.WriteLine($"Total is {total}");
question();
int count = 1;
while (count <= 10) {
    Console.WriteLine(count % 2 == 1 ? "****" : "++++++++");
    ++count;
}

section("While-lus oefeningen");
question();
const int getallen_size = 5;
Span<int> getallen = stackalloc int[getallen_size];
for (int i = 0; i < getallen_size; ++i) {
    getallen[i] = ask_int($"Geef getal {i+1}: ");
}
int sum = 0;
foreach (int i in getallen) sum += i; 
Console.WriteLine($"De som van de getallen is {sum}");
question();
for (int i = 0; i < getallen_size; ++i) {
    getallen[i] = ask_int($"Geef getal {i + 1} in: ");
}
int even_count = 0;
foreach (int i in getallen) even_count += (i % 2 == 0) ? 1 : 0;
int dividable_by_3_count = 0;
foreach (int i in getallen) dividable_by_3_count += (i % 3 == 0) ? 1 : 0;
Console.WriteLine($"Je gaf {even_count} even getallen en {dividable_by_3_count} getallen deelbaar door 3 in.");
question();
Console.WriteLine("N\t10*N\t100*N\t1000*N");
for (int i = 0; i < getallen_size; ++i) {
    Console.WriteLine($"{i}\t{10 * i}\t{100 * i}\t{1000 * i}");
}

section("For-lus ofeningen");
question();
int even_sum = 0;
for (int i = 1; i <= 500; ++i) {
    even_sum += (i % 12 == 0) ? i : 0;
}
Console.WriteLine(even_sum.ToString());
question();
for (int i = 51; i > 0; --i) {
    if (i % 2 == 1) {
        Console.WriteLine(i.ToString());
    }
}
question();
for (int i = (int)'a'; i <= (int)'z'; ++i) {
    Console.Write((char)i);
}
Console.WriteLine();

section("For-lus oefeningen - deel 2");
Console.WriteLine("zie oefening 2");

section("While-lus met schildwacht");
question();
const int sentinel = -1;
var inputs = new List<float>();
int input = sentinel;
do {
    input = ask_int("Geef een getal (-1 om te stoppen): ");
    if (input != sentinel) {inputs.Add(input);}
} while (input != sentinel);
if (inputs.Where(e => e < 0).Count() == 0) {
    Console.WriteLine($"Er werden geen negatieve getallen ingevoerd!");
} else {
    float avg = inputs.Sum() / inputs.Count();
    Console.WriteLine($"Het gemiddelde van alle negatieve getallen is {avg}");
}
question();
input = -1;
inputs.Clear();
while (input != 0) {
    input = ask_int("Geef een getal (0 om te stoppem): ");
    if (input == 0) continue;
    inputs.Add(input);
}
if (inputs.Count() == 0) {
    Console.WriteLine("Er werden geen geldige getallen ingevoerd!");
} else {
    int biggest = int.MinValue;
    int smallest = int.MaxValue;
    foreach (int i in inputs) {
        biggest = i > biggest ? i : biggest;
        smallest = i < smallest ? i : smallest;
    }
    Console.WriteLine($"Het grootste getal is {biggest}");
    Console.WriteLine($"Het kleinste getal is {smallest}");
}

section("do-while oefeningen");
question();
input = 1;
do {
    input = ask_int("strikt negatief getal: ");
} while(input >= 0);

question();
int i1, i2;
Func<int, int, bool> predicate = (i1, i2) => {
    bool cond = true;
    cond &= i1 != 1000;
    cond &= i1 % 12 != 0;
    cond &= i2 > i1;
    return cond;
};
do {
    i1 = ask_int("Eerste getal: ");
    i2 = ask_int("Tweede getal: ");
} while (!predicate(i1, i2));

section("Increment en Decrement");

/* util */
int ask_int(string? question = null, Func<int, bool>? predicate = null, string? failmsg = null) {
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
void section(string title) {
    question_counter = 0;
    Console.WriteLine($"\n{section_counter++}. {title}");
}
void question() {
    char c = (char)('A' + question_counter++);
    Console.WriteLine($"Vraag {c}:");
}

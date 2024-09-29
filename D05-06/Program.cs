int section_counter = 1;
int question_counter = 0;
//goto jmp;
new_section("De output van een applicatie met een lus");
new_question();
int y, x = 1, total = 0;
while (x <= 10) {
    y = x * x;
    Console.WriteLine(y.ToString());
    total += y;
    ++x;
}
Console.WriteLine($"Total is {total}");
new_question();
int count = 1;
while (count <= 10) {
    Console.WriteLine(count % 2 == 1 ? "****" : "++++++++");
    ++count;
}

new_section("While-lus oefeningen");
new_question();
const int getallen_size = 5;
Span<int> getallen = stackalloc int[getallen_size];
for (int i = 0; i < getallen_size; ++i) {
    getallen[i] = ask_int($"Geef getal {i+1}: ");
}
int sum = 0;
foreach (int i in getallen) sum += i; 
Console.WriteLine($"De som van de getallen is {sum}");
new_question();
for (int i = 0; i < getallen_size; ++i) {
    getallen[i] = ask_int($"Geef getal {i + 1} in: ");
}
int even_count = 0;
foreach (int i in getallen) even_count += (i % 2 == 0) ? 1 : 0;
int dividable_by_3_count = 0;
foreach (int i in getallen) dividable_by_3_count += (i % 3 == 0) ? 1 : 0;
Console.WriteLine($"Je gaf {even_count} even getallen en {dividable_by_3_count} getallen deelbaar door 3 in.");
new_question();
Console.WriteLine("N\t10*N\t100*N\t1000*N");
for (int i = 0; i < getallen_size; ++i) {
    Console.WriteLine($"{i}\t{10 * i}\t{100 * i}\t{1000 * i}");
}

new_section("For-lus ofeningen");
new_question();
int even_sum = 0;
for (int i = 1; i <= 500; ++i) {
    even_sum += (i % 12 == 0) ? i : 0;
}
Console.WriteLine(even_sum.ToString());
new_question();
for (int i = 51; i > 0; --i) {
    if (i % 2 == 1) {
        Console.WriteLine(i.ToString());
    }
}
new_question();
for (int i = (int)'a'; i <= (int)'z'; ++i) {
    Console.Write((char)i);
}
Console.WriteLine();

new_section("For-lus oefeningen - deel 2");
Console.WriteLine("zie oefening 2");

new_section("While-lus met schildwacht");
new_question();
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
new_question();
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

new_section("do-while oefeningen");
new_question();
input = 1;
do {
    input = ask_int("strikt negatief getal: ");
} while(input >= 0);
new_question();
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

new_section("Increment en Decrement");
int a = 0, b = 0, c = 0;
print(a = ++b + ++c);
print(a = b++ + c++);
print(a = ++b + c++);
print(a = b-- + c--);

new_section("Kilometers");
int km = ask_int("Geef een afstand in kilometer: ", e => e > 0, "strikt positief geheel getal, probeer opnieuw: ");
for (int v = 40; v <= 140; v += 10) {
    float tot = (float)km  / (float)v * 60;
    int min = (int)tot % 60;
    int hours = (int)tot / 60;
    print($"{km} km\t{v} km/u\t{hours} u {min} min");
}

new_section("Op één na grootste getal");
Span<int> one_off = stackalloc int[10];
foreach (ref int i in one_off) {
    i = ask_int("Geef getal in: ");
}
int bigg = int.MinValue;
int one_off_bigg = int.MinValue;
foreach (int i in one_off) {
    if (i > bigg) bigg = i;
    else if (i < bigg && i > one_off_bigg) one_off_bigg = i;
}
print("Het op één na grootste getal is", one_off_bigg);

new_section("Delers van een getal");
int n_to_divide = ask_int("Geef een strikt positief getal in: ", e => e > 0);
Console.Write("De delers zijn: ");
for (int d = 1; d <= n_to_divide / 2; ++d) {
    if (n_to_divide % d == 0) Console.Write($"{d} "); 
}
print("en", n_to_divide);

new_section("Wie is deelbaar door 2, 3 en 6");
var deelbaar = new List<int>();
while (true) {
    int i = ask_int("Positief getal (stoppen met 0): ", e => e >= 0);
    if (i == 0) break;
    deelbaar.Add(i);
}
int by_2_count = 0;
int by_3_count = 0;
int by_6_count = 0;
foreach (int i in deelbaar) {
    if (dividable(i, 2)) ++by_2_count;
    if (dividable(i, 3)) ++by_3_count;
    if (dividable(i, 6)) ++by_6_count;
}
print("Er zijn", by_2_count, "getallen deelbaar door", 2);
print("Er zijn", by_3_count, "getallen deelbaar door", 3);
print("Er zijn", by_6_count, "getallen deelbaar door", 6);

new_section("Deelbaar door een getal");
var is_positive = (int e) => e > 0;
int divider = ask_int("Geef een strikt positieve deler: ", is_positive); 
int dividable_counter = 0;
int iteration_count = 1;
while (true) {

    int my_int = ask_int($"Geef positief getal {iteration_count} in (of stop met -1): ", e => e > 0 || e == -1);
    if (my_int == -1) break;
    dividable_counter += dividable(my_int, divider) ? 1 : 0;
}
print("Er zijn", dividable_counter, "getallen deelbaar door", divider);

new_section("Algoritme");
int my_algorithm(int num, int depth = 0) {
    if (num == 1) return depth;
    if (dividable(num, 2)) {
        return my_algorithm(num / 2, ++depth);
    }
    return my_algorithm((num * 3) + 1, ++depth);
}
int n = ask_int("Geef een strikt positief geheel getal in: ", e => e > 0);
print("Het getal wijzigt", my_algorithm(n), "keer");

//jmp:
new_section("Patroon");
const int cols = 10;
const int rows = 10;
char[] screenbuffer = new char[cols * rows];
const char blank = ' ';
const char filled = '*';
char[] blank_col() {
    char[] col = new char[cols];
    for (int i = 0; i < col.Count(); ++i) col[i] = blank;
    return col;
}
char[] filled_col() {
    char[] col = new char[cols];
    for (int i = 0; i < col.Count(); ++i) col[i] = filled;
    return col;
}
void load_col(Span<char> data, ref char[] buffer, int row) {
    int start_idx = cols * row; 
    for (int i = start_idx; i < start_idx + cols; ++i) buffer[i] = data[i - start_idx];
}
void render(char[] buffer) {
    for (int i = 0; i < buffer.Count(); ++i) {
        if (i != 0 && i % cols == 0) Console.WriteLine();
        Console.Write(buffer[i]);
    }
    Console.WriteLine();
}
new_question();
for (int row = 0; row < rows; ++row) {
    char[] data = blank_col();
    for (int i = 0; i < row; ++i) data[i] = filled;
    load_col(data, ref screenbuffer, row);
}
render(screenbuffer);
new_question();
for (int row = 0; row < rows; ++row) {
    char[] data = filled_col();
    for (int i = 0; i < row; ++i) data[i] = blank;
    load_col(data, ref screenbuffer, row);
}
render(screenbuffer);
new_question();
for (int row = 0; row < rows; ++row) {
    int irow = rows - row;
    char[] data = blank_col();
    for (int i = irow -1; i >= 0; --i) data[i] = filled;
    load_col(data, ref screenbuffer, row);
}
render(screenbuffer);
new_question();
for (int row = 0; row < rows; ++row) {
    int irow = rows - row;
    char[] data = filled_col();
    for (int i = irow -1; i >= 0; --i) data[i] = blank;
    load_col(data, ref screenbuffer, row);
}
render(screenbuffer);
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
void new_section(string title) {
    question_counter = 0;
    Console.WriteLine($"\n{section_counter++}. {title}");
}
void new_question() {
    char c = (char)('A' + question_counter++);
    Console.WriteLine($"Vraag {c}:");
}
void print(params object[] args) {
    foreach (object obj in args) {
        Console.Write(obj?.ToString() ?? "#");
        Console.Write(" ");
    }
    Console.WriteLine();
}
bool dividable(int n, int by) {
    return n % by == 0;
}

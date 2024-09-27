namespace project;
using _dbg = System.Diagnostics.Debug;
using _con = System.Console;
using System.Reflection;
class Program {
    static void Main(string[] args) {
        var exercises = new List<Exercise>();
        Exercise.chainload_exercise_instances_to(ref exercises);
        if (args.Count() == 2 && args[0] == "oef") present(exercises[int.Parse(args[1]) - 1/*excl range*/]);
        else foreach (Exercise exercise in exercises) present(exercise);
        Console.WriteLine("\nprogram exited.\n");
    }
    static void present(in Exercise ex) {
        print_title_format(ex);
        ex.start();
    }
    static void print_title_format(in Exercise ex) {
        Console.WriteLine($"\n[{ex.nr_}] [ {ex.title_} ]:");
    }
}
class Exercise {
    static public void chainload_exercise_instances_to(ref List<Exercise> to) {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Func<Type, bool> is_exercise_t = (Type type) => type.IsSubclassOf(typeof(Exercise)); 
        IEnumerable<Type> found_derivations = assembly.GetTypes().Where(is_exercise_t); /* somehow is ordered already
        TODO: test if this is related to declaration order or not */ 
        foreach (var exercise in found_derivations) {
            Exercise? instance = Activator.CreateInstance(exercise) as Exercise;
            if (instance == null) _dbg.Fail($"Failed to init {exercise.Name}");//maybe try cs exceptions for this
            to.Add(instance);
        }
    }
    public Exercise(int nr, string title) {
        nr_ = nr;
        title_ = title;
    }
    public int nr_ = 0;
    public string title_ = "Oefening";
    virtual public void start() {
        _dbg.Print("t\not implemented yet.");
    }
    static protected void format_print(string str) {
        _con.Write("    " + str);
    }
}

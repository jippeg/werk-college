namespace project;
using System.Diagnostics;
using System.Reflection;
class Program {
    static void Main(string[] args) {
        var exercises = new List<Exercise>();
        Exercise.chainload_exercise_instances_to(ref exercises);
        if (args.Count() == 2 && args[0] == "oef") present(exercises[int.Parse(args[1]) - 1]);
        else foreach (Exercise exercise in exercises) present(exercise);
        Console.WriteLine("\nprogramma beëindigd.\n");
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
        Func<Type, bool> has_exercise_base = (Type type) => type.IsSubclassOf(typeof(Exercise)); 
        IEnumerable<Type> found_derivations = assembly.GetTypes().Where(has_exercise_base); 
        foreach (var exercise in found_derivations) {
            var instance = Activator.CreateInstance(exercise) as Exercise;
            if (instance == null) Debug.Fail($"failed to instantiate {exercise.Name}");
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
        Debug.Print("nog niet geïmplementeerd.");
    }
    static protected void format_print(string str) {
        Debug.Write("    " + str);
    }
}

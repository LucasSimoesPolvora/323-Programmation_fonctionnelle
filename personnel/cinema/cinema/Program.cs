List<Movie> frenchMovies = new List<Movie>() {
    new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
    new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
    new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
    new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
    new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
    new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
    new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};

// Filtre 1
List<Movie> filtre1 = frenchMovies.Where(movie => movie.Genre != "Comédie").Where(movie => movie.Genre != "Drame").ToList();
List<Movie> filtre1b = frenchMovies.Where(movie => movie.Genre != "Comédie" && movie.Genre != "Drame").ToList();
Console.WriteLine("Filtre 1 :");
filtre1.ForEach(movie => Console.WriteLine(movie.Title + " " + movie.Genre));

Console.WriteLine();

// Filtre 2
List<Movie> filtre2 = frenchMovies.Where(movie => movie.Rating < 7).ToList();
Console.WriteLine("Filtre 2 :");
filtre2.ForEach(movie => Console.WriteLine(movie.Title + " " + movie.Rating));

Console.WriteLine();

// Filtre 3
List<Movie> filtre3 = frenchMovies.Where(movie => movie.Year < 2000).ToList();
Console.WriteLine("Filtre 3 :");
filtre3.ForEach(movie => Console.WriteLine(movie.Title + " " + movie.Year));

Console.WriteLine();

// Filtre 4
List<Movie> filtre4 = frenchMovies.Where(movie => !movie.LanguageOptions.Contains("Français")).ToList();
Console.WriteLine("Filtre 4 :");
filtre4.ForEach(movie => 
    {
        Console.Write(movie.Title + " ");
        movie.LanguageOptions.ToList().ForEach(language => Console.Write("/ " + language + " "));
        Console.WriteLine();
    });

Console.WriteLine();


// Filtre 5
List<Movie> filtre5 = frenchMovies.Where(movie => !movie.StreamingPlatforms.Contains("Netflix")).ToList();
Console.WriteLine("Filtre 4 :");
filtre5.ForEach(movie =>
{
    Console.Write(movie.Title + " ");
    movie.StreamingPlatforms.ToList().ForEach(stream => Console.Write("/ " + stream + " "));
    Console.WriteLine();
});

Console.WriteLine();
// Cumul
List<Movie> cumul = frenchMovies.Where(movie => movie.Genre != "Comédie" && movie.Genre != "Drame" && 
                                                movie.Rating < 7 && 
                                                movie.Year < 2000 && 
                                                !movie.LanguageOptions.Contains("Français") &&
                                                !movie.StreamingPlatforms.Contains("Netflix")).ToList();
Console.WriteLine("Cumul :");
cumul.ForEach(movie =>
{
    Console.Write(movie.Title + " / " + movie.Genre + " / " + movie.Year);
    movie.LanguageOptions.ToList().ForEach(language => Console.Write("/ " + language + " "));
    movie.StreamingPlatforms.ToList().ForEach(stream => Console.Write("/ " + stream + " "));
    Console.WriteLine();
});

Console.WriteLine();

Console.WriteLine("Choisissez vos options :");
Console.Write("Genre : ");
string choixGenre = Console.ReadLine();

Console.Write("Rating minimum : ");
Int32.TryParse(Console.ReadLine(), out int choixRating);

Console.Write("Année minimum : ");
Int32.TryParse(Console.ReadLine(), out int choixYear);

Console.Write("Langue : ");
string choixLangue = Console.ReadLine();

Console.Write("Plateforme de streaming : ");
string choixPlatforme = Console.ReadLine();

List<Movie> choix = frenchMovies.Where(movie => movie.Genre == choixGenre &&
                                                movie.Rating > choixRating &&
                                                movie.Year > choixYear &&
                                                movie.LanguageOptions.Contains(choixLangue) &&
                                                movie.StreamingPlatforms.Contains(choixPlatforme)).ToList();
choix.ForEach(movie =>
{
    Console.Write(movie.Title + " / " + movie.Genre + " / " + movie.Year);
    movie.LanguageOptions.ToList().ForEach(language => Console.Write("/ " + language + " "));
    movie.StreamingPlatforms.ToList().ForEach(stream => Console.Write("/ " + stream + " "));
    Console.WriteLine();
});


Console.ReadLine();



public class Movie()
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public double? Rating { get; set; }
    public int? Year { get; set; }
    public string[]? LanguageOptions { get; set; }
    public string[]? StreamingPlatforms { get; set; }
}
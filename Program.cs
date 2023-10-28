List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


// Utilice LINQ para encontrar la primera erupción que se produce en Chile e imprima el resultado.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Primera erupción que se produce en Chile");
Console.WriteLine("-------------------------------------------------------------");
Eruption? primeraEnChile = eruptions.OrderBy(e => e.Year).ToList().FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine(primeraEnChile?.ToString());

// Encuentre la primera erupción en la ubicación de "Hawaiian Is" e imprímala. Si no se encuentra ninguno, imprima "No se encontró ninguna erupción hawaiana".
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("primera erupción en Hawaiian Is");
Console.WriteLine("-------------------------------------------------------------");
Eruption? primeraEnHawai = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if(primeraEnHawai ==null){
    Console.WriteLine("No se encontró ninguna erupción hawaiana");
}else{
    Console.WriteLine(primeraEnHawai?.ToString());
}

// Busque la primera erupción posterior al año 1900 Y en "Nueva Zelanda", luego imprímala.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("primera erupción posterior al año 1900 Y en Nueva Zelanda");
Console.WriteLine("-------------------------------------------------------------");
Eruption? pos1900InNZ = eruptions.Where(e => e.Year >= 1900).ToList().FirstOrDefault(e => e.Location == "New Zealand");
Console.WriteLine(pos1900InNZ?.ToString());

// Encuentre todas las erupciones donde la elevación del volcán sea superior a 2000 m e imprímalas.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("las erupciones donde la elevación del volcán sea superior a 2000 m");
Console.WriteLine("-------------------------------------------------------------");
List<Eruption> eruptionsSobre2000 = eruptions.Where(e => e.ElevationInMeters >= 2000).ToList();
foreach(Eruption eruption in eruptionsSobre2000){
    Console.WriteLine(eruption?.ToString());
}

// Encuentra todas las erupciones donde el nombre del volcán comienza con "L" e imprímelas. Imprima también el número de erupciones encontradas.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("las erupciones donde el nombre del volcán comienza con L");
Console.WriteLine("-------------------------------------------------------------");
List<Eruption> eruptionsConL = eruptions.Where(e => e.Volcano[0].Equals('L')).ToList();
foreach(Eruption eruption in eruptionsConL){
    Console.WriteLine(eruption?.ToString());
}

// Encuentre la elevación más alta e imprima solo ese número entero (Sugerencia: ¡busque cómo usar LINQ para encontrar el máximo!)
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Elevación del volcán más alto de la lista.");
Console.WriteLine("-------------------------------------------------------------");
int masAlto = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"{masAlto} m.");

// Utilice la variable de elevación más alta para buscar e imprimir el nombre del volcán con esa elevación.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine($"El volcán con una elevación de {masAlto} m.");
Console.WriteLine("-------------------------------------------------------------");
Eruption? maxElevationEruption = eruptions.Where(e => e.ElevationInMeters == masAlto).FirstOrDefault();
Console.WriteLine(maxElevationEruption?.ToString());

// Imprima todos los nombres de los volcanes alfabéticamente.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Volcanes ordenados alfabéticamente.");
Console.WriteLine("-------------------------------------------------------------");
List<Eruption> alfabeticEruption = eruptions.OrderBy(e => e.Volcano).ToList();
foreach(Eruption eruption in alfabeticEruption){
    Console.WriteLine(eruption.ToString());
}

// Imprima todas las erupciones que ocurrieron antes del año 1000 EC en orden alfabético según el nombre del volcán.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Erupciones antes del año 1000 ordenadas alfabéticamente.");
Console.WriteLine("-------------------------------------------------------------");
List<Eruption> alfabeticEruptionAntes1000 = eruptions.Where(e => e.Year <= 1000).OrderBy(e => e.Volcano).ToList();
foreach(Eruption eruption in alfabeticEruptionAntes1000){
    Console.WriteLine(eruption.ToString());
}

// BONUS: rehaga la última consulta, pero esta vez use LINQ para seleccionar solo el nombre del volcán para que solo se impriman los nombres.
Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine("Erupciones antes del año 1000 ordenadas alfabéticamente(solo nombres).");
Console.WriteLine("-------------------------------------------------------------");
List<string> alfabeticEruptionAntes1000Nombres = eruptions.Where(e => e.Year <= 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
foreach(string eruption in alfabeticEruptionAntes1000Nombres){
    Console.WriteLine(eruption);
}
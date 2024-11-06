using System;

public abstract class Figures // En abstrakt basclass för alla geometriska figurer som innehåller gemensamma egenskaper och metoder.
{
    public double Area { get; set; } // Properties för att lagra area och omkrets.
    public double Omkrets { get; set; }
    public abstract double getOmkrets(); // Abstrakta metoder som måste "implementeras" i varje figurclass.
    public abstract double getArea();
    public abstract string getFigureName();
}
public class Cirkel : Figures // Class för en cirkel, härleds från Figures-Classen.
{
    private double radie;

    public Cirkel(double radie)
    {
        this.radie = radie;
    }
    public override double getOmkrets() // Metod som beräknar och returnerar omkretsen av cirkeln.
    {
        Omkrets = 2 * Math.PI * radie;
        return Omkrets;
    }
    public override double getArea()
    {
        Area = Math.PI * radie * radie;
        return Area;
    }
    public override string getFigureName()
    {
        return "Cirkel";
    }
}

public class Rektangel : Figures // Class för en rektangel, också en subclass till Figures.
{
    private double längd;
    private double bredd;

    public Rektangel(double bredd, double längd)  // Konstruktor som tar bredd och längd som parametrar.
    {
        this.bredd = bredd;
        this.längd = längd;
    }
    public override double getOmkrets()
    {
        Omkrets = 2 * (längd + bredd);
        return Omkrets;
    }
    public override double getArea()
    {
        Area = längd * bredd;
        return Area;
    }
    public override string getFigureName()
    {
        return "Rektangel";
    }
}
public class Triangel : Figures // Class för en kvadrat, som också är en typ av figur.
{
    private double sidaA;
    private double sidaB;
    private double sidaC;

    public Triangel(double sidaA, double sidaB, double sidaC)
    {
        this.sidaA = sidaA;
        this.sidaB = sidaB;
        this.sidaC = sidaC;
    }
    public override double getOmkrets()
    {
        Omkrets = sidaA + sidaB + sidaC;
        return Omkrets;
    }
    public override double getArea()
    {
        double s = getOmkrets() / 2;
        Area = Math.Sqrt(s * (s - sidaA) * (s - sidaB) * (s - sidaC));
        return Area;
    }
    public override string getFigureName()
    {
        return "Triangel";
    }
}
public class Kvadrat : Figures
{
    private double sida;

    public Kvadrat(double sida)
    {
        this.sida = sida;

    }
    public override double getOmkrets()
    {
        Omkrets = 4 * sida;
        return Omkrets;
    }
    public override double getArea()
    {
        Area = sida * sida;
        return Area;
    }
    public override string getFigureName()
    {
        return "Kvadrat";
    }
}

public class Dialog // Class för att hantera användardialog, och en meny för att skapa olika figurer.
{
    static void visaCirkel()
    {
        Console.Write("Ange cirkelns radie: ");

        double resultat;

        while (!double.TryParse(Console.ReadLine(), out resultat))
        {
            Console.WriteLine("ogiltigt resultat!");
        }
        double radie = resultat;

        Cirkel cirkel = new Cirkel(radie);

        double area = cirkel.getArea();

        double omkrets = cirkel.getOmkrets();
        Console.WriteLine($"Arean av cirkeln är: {area}");
        Console.WriteLine($"Omkrets av cirkeln är: {omkrets}");

    }
    static void visaRektangel()
    {
        Console.Write("Ange rektangelns längd: ");

        double resultat1;
        while (!double.TryParse(Console.ReadLine(), out resultat1))
        {
            Console.WriteLine("Ogiltig inmatning!");
        }
        double längd = resultat1;
        Console.WriteLine("Ange rektangelns bredd: ");

        double resultat2;
        while (!double.TryParse(Console.ReadLine(), out resultat2))
        {
            Console.WriteLine("Ogiltig inmatning!");

        }
        double bredd = resultat2;

        Rektangel rektangel = new Rektangel(längd, bredd);

        double area = rektangel.getArea();
        double omkrets = rektangel.getOmkrets();

        Console.WriteLine($"Arean av rektangel är: {area}");
        Console.WriteLine($"Omkrets av rektangel är: {omkrets}");
    }
    static void visaTriangel()
    {
        Console.Write("Ange längden på sida A av triangeln: ");

        double resultat1;
        while (!double.TryParse(Console.ReadLine(), out resultat1))
        {
            Console.WriteLine("Ogiltig inmatning!");
        }
        double sidaA = resultat1;

        Console.Write("Ange längden på sida B av triangeln: ");

        double resultat2;
        while (!double.TryParse(Console.ReadLine(), out resultat2))
        {
            Console.WriteLine("Ogiltig inmatning!");

        }
        double sidaB = resultat2;

        Console.Write("Ange längden på sida C av triangeln: ");

        double resultat3;

        while (!double.TryParse(Console.ReadLine(), out resultat3))
        {
            Console.WriteLine("Ogiltig inmatning!");

        }

        double sidaC = resultat3;

        Triangel triangel = new Triangel(sidaA, sidaB, sidaC);

        double area = triangel.getArea();
        double omkrets = triangel.getOmkrets();

        Console.WriteLine($"Arean av triangeln är: {area}");
        Console.WriteLine($"Omkrets av triangeln är: {omkrets}");
    }
    static void visaKvadrat()
    {
        Console.Write("Ange kvadratens sida: ");

        double resultat;

        while (!double.TryParse(Console.ReadLine(), out resultat))
        {
            Console.WriteLine("ogiltigt resultat!");
        }
        double sida = resultat;

        Kvadrat kvadrat = new Kvadrat(sida);

        double area = kvadrat.getArea();

        double omkrets = kvadrat.getOmkrets();

        Console.WriteLine($"Arean av kvadraten är: {area}");
        Console.WriteLine($"Omkrets av kvadraten är: {omkrets}");

    }

    static void Main() // Main-metod för att hantera meny, och alternativ för att skapa olika figurer.
    {

        bool start = true;

        while (start)
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Skapa en cirkel");
            Console.WriteLine("2. Skapa en rektangel");
            Console.WriteLine("3. Skapa en triangel");
            Console.WriteLine("4. Skapa en kvadrat");
            Console.WriteLine("5. Avsluta");

            string alternativ = Console.ReadLine();

            switch (alternativ) // Använder switch-sats för att välja och visa rätt figur.
            {
                case "1":
                    visaCirkel();
                    break;
                case "2":
                    visaRektangel();
                    break;
                case "3":
                    visaTriangel();
                    break;
                case "4":
                    visaKvadrat();
                    break;
                case "5":
                    start = false;
                    Console.WriteLine("hejdå");
                    break;

                default:
                    Console.WriteLine("Ogiltig inmatning!");
                    break;
            }
        }
    }
}
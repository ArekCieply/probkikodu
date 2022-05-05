public class student
{
    public int nrindeks;
    public int wiek;
    public int rok;
    public int semestr;
    public String plec;
}
public class degree
{
    public String przedmiot;
    public int ocena;
    public int rokzal;
    public int semestr;
    public int nrstud;
}

static class program
{
    static void Main()
    {
        var studenci = new List<student>()
        {
            new student() { nrindeks = 1, wiek = 10, plec ="mężczyzna", rok = 1, semestr=2},
            new student() { nrindeks = 2, wiek = 20, plec ="mężczyzna", rok = 3, semestr=1},
            new student() { nrindeks = 3, wiek = 100, plec ="mężczyzna", rok = 1, semestr=1},
            new student() { nrindeks = 4, wiek = 23, plec ="mężczyzna", rok = 3, semestr=2},
            new student() { nrindeks = 5, wiek = 21, plec ="mężczyzna", rok = 1, semestr=2}
        };
        var oceny = new List<degree>()
        {
            new degree() {przedmiot="programowanie", ocena=3, rokzal=1, semestr=1, nrstud=1},
            new degree() {przedmiot="programowanie", ocena=4, rokzal=1, semestr=1, nrstud=2},
            new degree() {przedmiot="analiza matematyczna", ocena=2, rokzal=1, semestr=1, nrstud=3},
            new degree() {przedmiot="programowanie", ocena=5, rokzal=1, semestr=1, nrstud=4},
            new degree() {przedmiot="programowanie", ocena=3, rokzal=1, semestr=1, nrstud=5},
            new degree() {przedmiot="fizyka", ocena=3, rokzal=1, semestr=1, nrstud=1},
            new degree() {przedmiot="fizyka", ocena=3, rokzal=1, semestr=1, nrstud=2},
            new degree() {przedmiot="fizyka ", ocena=2, rokzal=1, semestr=1, nrstud=3},
            new degree() {przedmiot="fizyka", ocena=5, rokzal=1, semestr=1, nrstud=4},
            new degree() {przedmiot="fizyka", ocena=5, rokzal=1, semestr=1, nrstud=5}
        };

        var q0 =
            from c in studenci
            join p in oceny
            on c.nrindeks equals p.nrstud into ps
            select new { nr = c.nrindeks, oc = ps };


        foreach (var v in q0)
        {
            Console.WriteLine(v.nr + " indeks");
            foreach (var p in v.oc)
            {
                Console.WriteLine("\t" + p.ocena + " przedmiot " + p.przedmiot);
            }
        }

        var q =
            from s in studenci
            group s by s.rok into g
            select new
            {
                rok = g.Key,
                avgwiek = g.Average(p => p.wiek)
            };
        var q1 =
            from s in studenci
            select new
            {
                wiek = s.wiek,
                rok = s.rok,
                nr = s.nrindeks
            };
        foreach (var a in q)
        {
            foreach (var b in q1)
            {
                if (a.rok == b.rok && b.wiek > a.avgwiek)
                {
                    Console.WriteLine($" rok {a.rok} srednia {a.avgwiek} nr indeksu {b.nr} wiek {b.wiek}");

                }
            }

        }

        var q2 =
            from c in studenci
            group c by c.rok into g
            join p in oceny
            on g.FirstOrDefault().nrindeks equals p.nrstud into ps
            select new
            {
                oc = ps,
                srrok = ps.Average(p => p.ocena),
                rok = g.Key
            };
        var q3 =
            from c in oceny
            group c by c.nrstud into g
            join s in studenci
            on g.FirstOrDefault().nrstud equals s.nrindeks into g1
            select new
            {
                srstud = g.Average(p => p.ocena),
                nr = g.Key,
                g1.FirstOrDefault().rok
                
            };
        foreach (var a in q2)
        {
            foreach (var b in q3)
            {
                if (b.srstud > a.srrok && b.rok == a.rok)
                {
                    Console.WriteLine("\t student powyżej sr roku nr stud " + b.nr + " sr stud " + b.srstud+ " sr roku "+a.srrok+ " rok "+a.rok);
                }
            }
        }

    }
}
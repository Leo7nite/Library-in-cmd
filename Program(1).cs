using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aktivnost
{
    class GlavnoOkno
    {
        public SeznamUporabnikov Seznam;
        public Uporabnik Ustvarjanje;
        public Administrator UstvariAdmina;
        public Knjiga Izposoja;
        public Knjiga Rezervacija;
        public VnosKnjig Vnos;
        public SeznamKnjig SeznamKnjigic;
        public IsciKnjigo Isci;

        //METODA, KI IZBERE ADMINA V SWITCH "MAIN PROGRAMU"
        public void IzberiAd()
        {
            string odl;
            do
            {
                //SWITCH STAVEK, KJER KLIČEMO FUNKCIJE ZA IZPIS VSEH UPORABNIKOV, IZPIS ADMINOV, USTVARJANJE ADMINOV IN UPORABNIKOV, IN VNOS NOVIH KNJIG ZA NAKUP.
                Console.WriteLine("1 - Izpisi vse uporabnike");
                Console.WriteLine("2 - Izpisi vse admine");
                Console.WriteLine("3 - Ustvarjanje uporabnikov");
                Console.WriteLine("4 - Ustvarjanje adminov");
                Console.WriteLine("5 - Vnos knjig za nakup");
                Console.WriteLine("6 - Izhod");
                Console.WriteLine("IZBERI:");
                int izberi = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (izberi)
                {
                    case 1:
                        Seznam = new SeznamUporabnikov();
                        Seznam.IzpisUporabnikov();
                        break;
                    case 2:
                        Seznam = new SeznamUporabnikov();
                        Seznam.IzpisAdminov();
                        break;
                    case 3:
                        Ustvarjanje = new Uporabnik();
                        Ustvarjanje.UstvarjanjeUporabnika();
                        break;
                    case 4:
                        UstvariAdmina = new Administrator();
                        UstvariAdmina.UstvarjanjeAdminov();
                        break;
                    case 5:
                        Vnos = new VnosKnjig();
                        Vnos.VnesiKnjigo();
                        break;
                    case 6:
                        Console.WriteLine("Adijo!");
                        return;
                      
                }
                
                Console.WriteLine("Zelite narediti kaj drugega? Y/N");
                odl = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Adijo!");
            } while (odl != "N" && odl != "n");
            
        }
        //METODA, KI IZBERE UPORABNIKA V SWITCH MAIN PROGRAMU.
        public void IzberiUp()
        {
            string odl;
            do
            {
                Console.WriteLine("1 - Izposoja knjig, ki so na voljo.");
                Console.WriteLine("2 - Rezervacija knjig, ki so na voljo.");
                Console.WriteLine("3 - Seznam knjig, ki jih lahko kupiš.");
                Console.WriteLine("4 - Išči knjige (avtor, naslov,..)");
                Console.WriteLine("5 - Nakup knjig.");
                Console.WriteLine("6 - Izhod");
                Console.WriteLine("Izberi: ");
                int izberi = int.Parse(Console.ReadLine());
                Console.Clear();

                //SWITCH STAVEK, S KATERIM LAHKO IZBEREMO KAJ ŽELIMO NAREDITI KOT UPORABNIK.
                switch (izberi)
                {
                    case 1:
                        Izposoja = new Knjiga();
                        Izposoja.IzposojaKnjig();
                        Console.WriteLine("IZBERI: ");
                        int vnos = int.Parse(Console.ReadLine());
                        switch (vnos)
                        {
                            case 1:
                                Console.WriteLine("Izposodil si knjigo - Hobbit the Unexpected Journey!");
                                break;
                            case 2:
                                Console.WriteLine("Izposodil si knjigo - Harry Potter and the Deathly Hallows - part 1!");
                                break;
                            case 3:
                                Console.WriteLine("Izposodil si knjigo - The Magicians!");
                                break;
                            case 4:
                                Console.WriteLine("Izposodil si knjigo - The Gospel of Loki!");
                                break;

                        }
                        break;
                    case 2:
                        Rezervacija = new Knjiga();
                        Rezervacija.RezervacijaKnjig();
                        Console.WriteLine("IZBERI: ");
                        vnos = int.Parse(Console.ReadLine());
                        
                        switch (vnos)
                        {
                            case 1:
                                Console.WriteLine("Rezervirali ste knjigo - The Lord of the Rings!");
                                break;
                            case 2:
                                Console.WriteLine("Rezervirali ste knjigo - Igra prestolov!");
                                break;
                            case 3:
                                Console.WriteLine("Rezervirali ste knjigo - Veliki Gatsby!");
                                break;
                            case 4:
                                Console.WriteLine("Rezervirali ste knjigo - Aličine dogodivščine v čudežni deželi!");
                                break;
                            
                        }
                        break;
                    case 3:
                        SeznamKnjigic = new SeznamKnjig();
                        Console.WriteLine("SEZNAM VSEH KNJIG, KI SO NA VOLJO ZA NAKUP");
                        SeznamKnjigic.SeznamVsehKnjig();
                        Console.WriteLine();
                        break;
                    case 5:
                        SeznamKnjigic = new SeznamKnjig();
                        SeznamKnjigic.IzberaKnjige();
                        Console.WriteLine();
                        break;
                    case 4:
                        Isci = new IsciKnjigo();
                        Isci.FindBook();
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Adijo!");
                        return;


                }
                Console.WriteLine("Želite narediti kaj drugega? Y/N?");
                odl = Console.ReadLine();
                Console.Clear();
            } while (odl != "N" && odl != "n");
            Console.WriteLine("Adijo!");
        }
       
    }
    class Administrator
    {
        
        public string DatotekaAd = @"E:\School\Aktivnost\admin.txt";
        public GlavnoOkno glavnoOkno;
        
        //METODA ZA USTVARJANJE ADMINOV
        public void UstvarjanjeAdminov()
        {
            Console.WriteLine("USTVARJANJE NOVEGA ADMINA");
            Console.WriteLine("Vpiši uporabniško ime: ");
            string uporabniskoIme = Console.ReadLine();
            Console.WriteLine("Vpiši password: ");
            string password = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(@"E:\School\Aktivnost\admin.txt", append: true))
            {
                sw.WriteLine(uporabniskoIme);
                sw.WriteLine(password);
                sw.Close();
            }
        }
        //METODA ZA LOGIN ADMINA
        public void LoginAdmin()
        {
            bool pravilno = false;
            string uporabniskoIme, password = string.Empty;
            do
            {
                Console.WriteLine("Vpiši uporabniško ime: ");
                uporabniskoIme = Console.ReadLine();
                Console.WriteLine("Vpiši password: ");
                password = Console.ReadLine();
                Console.Clear();

                //PREBERE VSE LINIJE V TXT. DATOTEKI ADMINOV IN JIH DA V LIST
                List<string> admini = File.ReadAllLines(DatotekaAd).ToList();
                
                for (int i = 0; i < admini.Count - 1; i++)
                {
                    //PREVERJANJE ČE LIST VSEBUJE IME in PASSWORD.
                    pravilno = (admini[i].Contains(uporabniskoIme) && admini[i + 1].Contains(password));
                    // Če list vsebuje ime in geslo, potem odpri glavno okno za admine.
                    if (pravilno == true)
                    {
                        glavnoOkno = new GlavnoOkno();
                        glavnoOkno.IzberiAd();
                        break;
                    }
                }
            } while (pravilno == false);
        }
    }
    class Uporabnik
    {
        public string DatotekaUp = @"E:\School\Aktivnost\uporabniki.txt";
        public GlavnoOkno glavnoOkno;

        //METODA ZA USTVARJANJE UPORABNIKOV
        public void UstvarjanjeUporabnika()
        {
            Console.WriteLine("USTVARJANJE NOVEGA UPORABNIKA!");
            Console.WriteLine("Vpiši uporabniško ime: ");
            string uporabniskoIme = Console.ReadLine();
            Console.WriteLine("Vpiši password: ");
            string password = Console.ReadLine();

            //STREAMWRITER ZAPISE NAŠE VNEŠENO IME IN GESLO V UPORABNIKI.TXT
            using (StreamWriter sw = new StreamWriter(@"E:\School\Aktivnost\uporabniki.txt", append: true))
            {
                sw.WriteLine(uporabniskoIme);
                sw.WriteLine(password);
                sw.Close();
            }
        }
        //METODA ZA LOGIN UPORABNIKA - ISTO KOT PRI ADMINU
        public void LoginUporabnik()
        {
            bool pravilno = false;
            string uporabniskoIme, password = string.Empty;
            do
            {

                Console.WriteLine("Vpiši uporabniško ime: ");
                uporabniskoIme = Console.ReadLine();
                Console.WriteLine("Vpiši password: ");
                password = Console.ReadLine();
                Console.Clear();
                List<string> admini = File.ReadAllLines(DatotekaUp).ToList();

                for (int i = 0; i < admini.Count - 1; i++)
                {
                    pravilno = (admini[i].Contains(uporabniskoIme) && admini[i + 1].Contains(password));
                    if (pravilno == true)
                    {
                        glavnoOkno = new GlavnoOkno();
                        glavnoOkno.IzberiUp();
                        break;
                    }
                }
            } while (pravilno == false);

        }
    }
    class SeznamUporabnikov
    {
        //METODA ZA IZPIS VSEH UPORABNIKOV
        public void IzpisUporabnikov()
        {
            string datoteka = @"E:\School\Aktivnost\uporabniki.txt";
            List<string> uporabniki = File.ReadLines(datoteka).ToList();

            uporabniki.ToArray();
            
            for(int i = 0; i < uporabniki.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}. uporabnik: {1}",(i/2)+1,uporabniki[i]);
                }
            }
        }
        //METODA ZA IZPIS ADMINOV
        public void IzpisAdminov()
        {
            string datotekaAd = @"E:\School\Aktivnost\admin.txt";
            List<string> admini = File.ReadLines(datotekaAd).ToList();

            admini.ToArray();

            for(int i =0; i<admini.Count; i++)
            {
                if (i%2 == 0)
                {
                    Console.WriteLine("{0}. admin: {1}",(i/2)+1, admini[i]);
                }
            }
        }

    }
    class Knjiga
    {
        public int Id;
        public string Naslov;
        public string Avtor;
        public string VrstaKnjige;
        public string JezikDela;
        public Knjiga()
        {

        }
            
        public Knjiga(int id, string naslov, string avtor, string vrstaKnjige,  string jezikDela)
        {
            Id = id;
            Naslov = naslov;
            Avtor = avtor;
            VrstaKnjige = vrstaKnjige;
            JezikDela = jezikDela;
        }
        public void NaVoljo()
        {
            
            Console.WriteLine("{0}. {1}, {2} - {3} // {4}.", Id, Naslov, Avtor, VrstaKnjige, JezikDela);
        }

        
        public void IzposojaKnjig()
        {
            Knjiga hobit = new Knjiga(1, "Hobbit - The Unexpected Journey", "J.R.R. Tolkien", "Adventure/Action/Fantasy", "English");
            Knjiga harryPotter = new Knjiga(2, "Harry Potter and the Deathly Hallows part 1", "J.K. Rowling", "Adventure/Fantasy", "English");
            Knjiga magicians = new Knjiga(3, "The Magicians", "Lev Grossman", "Fantasy", "English");
            Knjiga loki = new Knjiga(4, "The Gospel of Loki", "Joanne M. Harris", "Fantasy", "English");

            hobit.NaVoljo();
            harryPotter.NaVoljo();
            magicians.NaVoljo();
            loki.NaVoljo();



        }
        public void RezervacijaKnjig()
        {
            Console.WriteLine("Katero knjigo si želite rezervirati? ");
            Knjiga lotr = new Knjiga(1, "The Lord of the Rings", "J.R.R. Tolkien", "Fantasy/Adventure", "English");
            Knjiga got = new Knjiga(2, "Igra prestolov", "George R.R. Martin", "Fantasy/Action/Drama", "Slovensko");
            Knjiga gatsby = new Knjiga(3, "Veliki Gatsby", "Francis Scott Key Fitzgerald","Drama", "Slovensko");
            Knjiga wonderland = new Knjiga(4, "Aličine dogodivščine v čudežni deželi", "Lewis Carroll","Fantasy", "Slovensko");
            lotr.NaVoljo();
            got.NaVoljo();
            gatsby.NaVoljo();
            wonderland.NaVoljo();
            
        }

    }
    class SeznamKnjig
    {
        public string datotekaKnjig = @"E:\School\Aktivnost\Knjige.txt";
        //METODA, KI IZPIŠE VSE KNJIGE, KI JIH IMAMO V LISTU.
        public void SeznamVsehKnjig()
        {
            List<string> knjige = File.ReadAllLines(datotekaKnjig).ToList();
            knjige.ToArray();
            
            foreach(string x in knjige)
            {
                Console.WriteLine(x);
            }

        }
        public void IzberaKnjige()
        {
            //METODA, S KATERO LAHKO IZBEREMO KNJIGO
            List<string> knjige = File.ReadAllLines(datotekaKnjig).ToList();
            knjige.ToArray();
            Console.WriteLine("IZBERI KNJIGO, KI JO ŽELIŠ KUPITI: ");
            int izbira = int.Parse(Console.ReadLine());

            //PREŠTEJE KOLIKO LINIJ JE V TXT. DATOTEKI, ČE JE VNEŠENO ŠTEVILO VEČJE KOT JE ŠT. VNEŠENIH KNJIG, IZPIŠE DA KNJIGA NE OBSTAJA.
            if (izbira > knjige.Count)
            {
                Console.WriteLine("Knjiga ne obstaja!");
            }
            else
            {
                Console.Write(knjige[izbira]);
                Console.WriteLine();
                Console.WriteLine("HVALA ZA NAKUP. KNJIGA BO POSLANA JUTRI!");
            }
        }
    }
    class VnosKnjig
    {
        public string datotekaKnjig = @"E:\School\Aktivnost\Knjige.txt";
        public string Naslov;
        public int Id;
        public string Avtor;
        public string Genre;
        public string Jezik;
        //Metoda za vnos novih knjig v list.
        public void VnesiKnjigo()
        {
            Console.WriteLine("Vnesi id: ");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Naslov: ");
            Naslov = Console.ReadLine();
            Console.WriteLine("Avtor: ");
            Avtor = Console.ReadLine();
            Console.WriteLine("Žanr: ");
            Genre = Console.ReadLine();
            Console.WriteLine("Jezik dela: ");
            Jezik = Console.ReadLine();
            List<string> knjige = File.ReadAllLines(datotekaKnjig).ToList();
            knjige.Add(Id + ". "+Naslov+", "+Avtor+" - "+Genre+" // "+Jezik+".");
            File.WriteAllLines(datotekaKnjig, knjige);

        }
    }
    
    class IsciKnjigo
    {
        public string Datoteka = @"E:\School\Aktivnost\Knjige.txt";
        //METODA, KI IŠČE KNJIGE V LISTU (po imenu, avtorju, žanru). Npr. vpišemo Harry in nam izpiše vse knjige, ki vsebujejo ime "Harry".
        public void FindBook()
        {
            Console.WriteLine("Išči po imenu knjige, avtorju ali žanru.");
            string isci = Console.ReadLine();

            List<string> knjige = File.ReadAllLines(Datoteka).ToList();

            string[] array = knjige.ToArray();

            foreach (string x in array)
            {
                if (x.Contains(isci) == true)
                {
                    Console.WriteLine(x.ToString());
                }
            }
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            
            //SWITCH STAVEK, DA KLIČEMO FUNKCIJO PRIJAVE KOT ADMIN ALI PA UPORABNIK. 
            int vnos;
            Console.WriteLine("KNJIŽNICA!");
            Console.WriteLine("1 - Prijava administratorja");
            Console.WriteLine("2 - Prijava uporabnika\n");
            Console.Write("Izbira: ");
            vnos = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (vnos)
            {
                case 1:
                    Administrator prijavaAdmin = new Administrator();
                    prijavaAdmin.LoginAdmin();
                    break;
                case 2:
                    Uporabnik prijavaUporabnika = new Uporabnik();
                    prijavaUporabnika.LoginUporabnik();
                    break;
            }


        }
    }
}


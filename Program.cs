using Uby;

namespace uby;

class Program{
    public static void Main(string[] args)
    {
        u = new Ubytovani(){};
        if(u.NactiTridu() == 1){
            Console.WriteLine("Načíst data ze souboru?");

        }
        if(u.getBool()){
            menu();
        }else
        {
                string[] arr = new string[3];
                Console.WriteLine("Vloz jmeno ubytování");
                arr[0] = u.getStr();
                Console.WriteLine("Vloz adresu ubytování");
                arr[1] = u.getStr();
                Console.WriteLine("Vloz kapacitu ubytování");
                arr[2] = u.getInt().ToString();
                Console.WriteLine("Chceš vložit nové klienty?");
                List<Host> builder = new List<Host>();
                while(u.getBool()){
                    builder.Add(u.addAHost());
                    Console.WriteLine("Další?");
                }
                u=new Ubytovani(){
                    nazev = arr[0],
                    adresa  = arr[1],
                    kapacita = int.Parse(arr[2]),
                    klienti = builder
                };
                menu();
        }      
    }
    public static void menu(){

        while(true){
        Console.Clear();
        Console.WriteLine("X - exit, R - remove, A - add, S - save, L - list");
            switch(char.ToLower(u.getChar())){
                case 'x':
                return;
                case 'r':
                Console.Clear();
                u.listHostages();
                int index = u.getInt();
                Console.WriteLine("Vlož index klienta");
                if(index < 0 || index >= u.klienti.Count){
                    Console.WriteLine("Index out of range");
                break;
                }
                u.klienti.RemoveAt(index);
                break;
                case 'a':
                u.klienti.Add(u.addAHost());
                break;
                case 's':
                u.UlozTridu();
                Console.Clear();
                Console.WriteLine("Saved!");
                Console.ReadKey();
                break;
                case 'l':
                Console.Clear();
                u.listHostages();
                Console.WriteLine("Aktuální obsazenost: "+u.akt_obsazenost+"/"+u.kapacita);
                Console.ReadKey();
                break;
            }
        }
    }
    public static Ubytovani u=new Ubytovani();
}
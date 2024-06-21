using System.Reflection;
using uby;

namespace Uby;

class Ubytovani{
    public Ubytovani(){
            
            _nazev="";
            _adresa="";
            _klienti=new List<Host>();
    }
    private string _nazev;
    public string nazev
    {
        get { return _nazev; }
        set { _nazev = value; }
    }
    private List<Host> _klienti;
    public List<Host> klienti
    {
        get { return _klienti; }
        set { _klienti = value; }
    }
    private string _adresa;
    public string adresa
    {
        get { return _adresa; }
        set { _adresa = value; }
    }
    private int _kapacita;
    public int kapacita
    {
        get { return _kapacita; }
        set { _kapacita = value; }
    }
    public int akt_obsazenost {
         get { 
        int num = 0;    
        foreach(Host hs in _klienti)
        {
            num+=hs.count;
        }
        return num;
        }
        
    }
    public bool obsazeno
    {
        get { return akt_obsazenost>=kapacita?true:false;}
    }
    public Host addAHost(){
        Console.WriteLine("Setup nového klienta");
        Console.WriteLine("Zadej jméno");
        string[] arr = new string[3];
        bool[] obarr = new bool[2];
        arr[0] = getStr();
        Console.WriteLine("Zadej příjmení");
        arr[1] = getStr();
        Console.WriteLine("Zadej kontakt");
        arr[2] = getStr();
        Console.WriteLine("Vydal doklad totožnosti?");
        obarr[0] = getBool();
        Console.WriteLine("Zaplatil?");
        obarr[1] = getBool();
        Console.WriteLine("Kolik členů má skupina, pokud je jen jeden, zadejte 1");
        int num;
        while(true)
        {
        num = getInt();
        if(num>kapacita-akt_obsazenost||num<=0){Console.WriteLine("Není možné zaregistrovat takovýto počet osob");}else{break;}}
        Host host = new Host(){
            jmena=arr[0],
            prijmeni=arr[1],
            kontakt=arr[2],
            potvrzeniTotoznosti=obarr[0],
            paid=obarr[1],
            count=num
        };
        return host;
    }
    public string getStr(){
        while (true){
            string? str = Console.ReadLine();
            if (str == null || str =="")
            {
                Console.WriteLine("Neplatný vstup");
                continue;
            }
            return str;
        }
    }
        public char getChar(){
        while (true){
            char str = Console.ReadKey().KeyChar;
            if (str == ' ')
            {
                Console.WriteLine("Neplatný vstup");
                continue;
            }
            return str;
        }
    }
        public bool getBool(){
            Console.WriteLine("Y-Ano, N-Ne");
            return char.ToLower(getChar())=='y'?true:false;
    }
    public int getInt(){
        int num;
        
        while(!int.TryParse(Console.ReadLine(), out num)){
            Console.WriteLine("Bad input");
        };
        return num;
    }
    public int NactiTridu(){
    
    StreamReader sr = new StreamReader("Hello.txt");
    string? str;
    bool first = true;
    List<Host> temp = new List<Host>();
    string[] valsU = new string[3];
    while( ( str = sr.ReadLine() )!=null){
        
        int j = 0;
        string strBuilder = "";
        if(first)
        {
            
           for (int i = 0; i < str.Length; i++){
                if( str[i] != '░'){
                    
                    strBuilder += str[i];
                    
                }else{
                valsU[j++] = strBuilder;
                strBuilder="";
                }
            }

            first = false;
            continue;
        }
        string[] vals = new string[6];
        j = 0;
        for (int i = 0; i < str.Length; i++){
            if( str[i] != '░'){
                
                 strBuilder += str[i];
                
            }else{
            vals[j++] = strBuilder;
            strBuilder="";
            }
        }
        
        Host host = new Host(){
            jmena=vals[0],
            prijmeni=vals[1],
            kontakt=vals[2],
            potvrzeniTotoznosti=bool.Parse(vals[3]),
            paid=bool.Parse(vals[4]),
            count=int.Parse(vals[5])

        };

       temp.Add(host);
        }
            Program.u=new Ubytovani(){
            nazev=valsU[0],
            adresa=valsU[1],
            kapacita=int.Parse(valsU[2]),
            _klienti=temp
            
        };
    sr.Close();
    if(!first)
    return 1;
    return 0;
    }
    public Exception UlozTridu()
    {
        
        StreamWriter writer = new StreamWriter("Hello.txt");
        
       writer.WriteLine(_nazev + "░" + _adresa + "░" + _kapacita + "░" );
        
        
        foreach(Host host in _klienti){
            writer.WriteLine(host.jmena + "░" + host.prijmeni + "░" + host.kontakt + "░" + host.potvrzeniTotoznosti + "░" + host.paid + "░" + host.count + "░");
        }
        
        writer.Flush();
        writer.Close();
        
    
        return new Exception("");
    }
    public void listHostages(){
        int i = 0;
        foreach(Host host in Program.u._klienti){
            Console.WriteLine(i+++"| "+Blue+host.jmena+Red+" "+host.prijmeni+Yellow+" "+host.count+Reset);
        }
    }
    static string Blue = "\u001b[34m";
    static string Reset = "\u001b[0m";
    static string Red = "\u001b[31m";
    static string Yellow = "\u001B[33m";    
}
class Host{
    public Host(){
        _jmena="";
        _prijmeni="";
        _kontakt="";
    }
    private string _jmena;
    public string jmena
    {
        get { return _jmena; }
        set { _jmena = value; }

    }
    private string _prijmeni;
    public string prijmeni
    {
        get { return _prijmeni; }
        set { _prijmeni = value; }
    }
    private string _kontakt;
    public string kontakt
    {
        get { return _kontakt; }
        set { _kontakt = value; }
    }
    private bool _potvrzeniTotoznosti;
    public bool potvrzeniTotoznosti
    {
        get { return _potvrzeniTotoznosti; }
        set { _potvrzeniTotoznosti = value; }
    }
    private bool _paid;
    public bool paid
    {
        get { return _paid; }
        set { _paid = value; }
    }
private int _count;
public int count
{
    get { return _count; }
    set { _count = value; }
}

}